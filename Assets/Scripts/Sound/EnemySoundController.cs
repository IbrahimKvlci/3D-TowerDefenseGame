using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [field: SerializeField] public EnemySoundEffectsSO EnemySoundEffectsSO { get; set; }

    public AudioSource EnemyAudioSource { get; set; }

    private float audioSourceVolume;

    private void Awake()
    {
        EnemyAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSourceVolume = EnemyAudioSource.volume;
    }

    public void StartAudio(AudioClip audioClip)
    {
        if (audioClip != null)
        {
            EnemyAudioSource.clip = audioClip;

            EnemyAudioSource.Play();
        }
    }

    public void StopAudio()
    {
        StartCoroutine(InGameSoundManager.Instance.FadeOut(EnemyAudioSource,0.5f));
    }

    

}
