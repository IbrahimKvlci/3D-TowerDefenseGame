using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceSingle : MonoBehaviour
{
    private AudioSource audioSource;
    private float timer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(audioSource.clip!= null)
        {
            timer += Time.deltaTime;
            if(timer > audioSource.clip.length)
            {
                audioSource.clip = null;
                timer = 0;
            }
        }
        
    }


}
