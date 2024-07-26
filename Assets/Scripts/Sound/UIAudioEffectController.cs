using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioEffectController : MonoBehaviour
{
    [field:SerializeField] public UISoundEffectsSO UISoundEffectsSO { get; private set; }

    private AudioSource audioSource;

    private float timer;

    public static UIAudioEffectController Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(audioSource.clip != null)
        {
            timer += Time.deltaTime;
            if (timer > audioSource.clip.length)
            {
                timer = 0;
                audioSource.clip = null;
            }
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
