using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour {

    public static MainMenuAudio instance;
    //public Sound menuMusic, fire;
    private AudioSource menuMusic, fire;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        menuMusic = GetComponent<AudioSource>();
        fire = GetComponent<AudioSource>();
        //source.Play();
        //playMenuMusic(source);
        //playFireSound(source);
        menuMusic.Play();
        fire.Play();
    }

    /*
    public void playMenuMusic(AudioSource source)
    {
        source.PlayOneShot(menuMusic.clip, menuMusic.pitch);
    }

    public void playFireSound(AudioSource source)
    {
        source.PlayOneShot(fire.clip, fire.pitch);
    }*/
}
