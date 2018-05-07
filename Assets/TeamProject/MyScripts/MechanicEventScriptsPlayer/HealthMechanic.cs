using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMechanic : MonoBehaviour {

    private ParticleSystem _psystem;
    public GameObject healthSlider;

    private AudioSource source;
    private CustomAudioManager amscript;

    void Awake()
    {
        _psystem = GetComponent<ParticleSystem>();
    }
	// Use this for initialization
	void Start () {
        GetComponent<customCharController>().OnHPpctsChanged += HandleHPChange;

        source = GetComponent<AudioSource>();
        amscript = GameObject.Find("AudioManagerCust").GetComponent<CustomAudioManager>();
    }
	
	void HandleHPChange(int damage)
    {
        amscript.playCutSounds(source);//audio
        GetComponent<customCharController>().currentHealth -= damage;
        healthSlider.GetComponent<HealthScript>().AdjustSlider(damage, this.tag);
        _psystem.Play();
        
    }
}
