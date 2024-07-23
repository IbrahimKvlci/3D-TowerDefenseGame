using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundManager : MonoBehaviour
{
    [field:SerializeField] public InGameSoundEffectsSO InGameSoundEffectsSO { get; set; }

    public static InGameSoundManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }


    public void PlayAudio(AudioClip audioClip,Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position,volume);
    }

    public void PlayAudioOnCamera(AudioClip audioClip, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
    }

    public void PlayAudioNormalized(AudioClip audioClip,Vector3 position, float volume = 1f)
    {
        Vector3 pos=position-Camera.main.transform.position;
        pos.Normalize();

        AudioSource.PlayClipAtPoint(audioClip, pos+Camera.main.transform.position, volume);
    }
}
