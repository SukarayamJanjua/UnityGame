using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    //public AudioClip coinsSound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.CoinsSound();
    }
    public void MuteMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }


   
}
