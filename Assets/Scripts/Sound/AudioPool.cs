using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPool : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourcePrefab;

    public List<AudioSource> AudioSourceList { get; set; }

    [SerializeField] private int audioSourceCount;
    [SerializeField] private int maxCountAudio;

    public static AudioPool Instance { get; set; }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        AudioSourceList = new List<AudioSource>();
    }

    private void Start()
    {
        CreateAudioSources();
    }

    public void PlayAudio(AudioClip audioClip)
    {
        if (!CheckListHasAudioMaxCount(audioClip))
        {
            AudioSource audioSource= GetEmptyAudioSource();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    private AudioSource GetEmptyAudioSource()
    {
        foreach (AudioSource audioSourceItem in AudioSourceList)
        {
            if (audioSourceItem.clip == null)
                return audioSourceItem;
        }

        AudioSource audioSource = Instantiate(audioSourcePrefab, transform);
        AudioSourceList.Add(audioSource);
        return audioSource;
    }

    private bool CheckListHasAudioMaxCount(AudioClip clip)
    {
        int count = 0;
        foreach (AudioSource audioSource in AudioSourceList)
        {
            if (audioSource.clip==clip)
                count++;

        }

        if (count >= maxCountAudio)
            return true;
        return false;
    }

    private void CreateAudioSources()
    {
        for (int i = 0; i < audioSourceCount; i++)
        {
            AudioSource audioSource = Instantiate(audioSourcePrefab, transform);
            AudioSourceList.Add(audioSource);
        }
    }
}
