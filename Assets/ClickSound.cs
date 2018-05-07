using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour {

    public AudioClip sound;


    public GameObject soundhelper;
    public AudioSource src;
    // Use this for initialization
    void Start () {
        /*
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
        */
        soundhelper = GameObject.FindWithTag("soundhelper");
        src = soundhelper.GetComponent<AudioSource>();

    }
	


    public void PlaySound()
    {
        src.PlayOneShot(src.clip);
        
    }

    
}
