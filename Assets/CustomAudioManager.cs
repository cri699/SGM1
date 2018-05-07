using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAudioManager : MonoBehaviour
{   

    public Sound[] meleeSounds, arrowSounds, dieSounds, footstepsSounds, cutSounds, tauntSounds, swordSwingSounds, hitSounds, treeHitSounds, fightMusic;
    public static CustomAudioManager instance;
    public Sound menuMusic;

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

        DontDestroyOnLoad(gameObject);
        /*
        initializeSounds(meleeSounds);
        initializeSounds(arrowSounds);
        initializeSounds(dieSounds);
        initializeSounds(footstepsSounds);
        initializeSounds(cutSounds);
        initializeSounds(tauntSounds);*/

    }
    /*
        void Start()
        {
            Play("Theme");
        }


        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Song: " + name + " doesn't exist.");
                return;
            }
            s.source.Play();
        }

    public void initializeSounds(Sound[] sounds)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }*/

    public void playDie(AudioSource source)
    {
        int x = customRandomize(dieSounds);
        source.PlayOneShot(dieSounds[x].clip, dieSounds[x].pitch);
    }

    public void playAttack(AudioSource source)
    {
        /*
        int chance = UnityEngine.Random.Range(0, 10);
        if (chance<2)
        {
            int x = customRandomize(meleeSounds);
            source.PlayOneShot(meleeSounds[x].clip, meleeSounds[x].pitch);
        }
        */

        source.PlayOneShot(swordSwingSounds[0].clip, swordSwingSounds[0].pitch);   //only 1 sound
    }

    public void playShootArrow(AudioSource source)
    {
        source.PlayOneShot(arrowSounds[0].clip, arrowSounds[0].pitch);   //only 1 sound
    }

    public void playCutSounds(AudioSource source)
    {
        int x = customRandomize(cutSounds);
        source.PlayOneShot(cutSounds[x].clip, cutSounds[x].pitch);
    }

    public void playTreeHitSounds(AudioSource source)
    {
        source.PlayOneShot(treeHitSounds[0].clip, treeHitSounds[0].pitch);   //only 1 sound
    }

    public int customRandomize(Sound[] sounds)
    {
        float x = sounds.Length;
        return (int)UnityEngine.Random.Range(0f, x);
    }
}


