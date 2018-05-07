using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {


	public GameObject slider;
	public GameObject Player;
    private customCharController player;
	// Use this for initialization
	void Start () {
        
        
        
	}
	
	// Update is called once per frame
	public void AdjustSlider(int damage, string tag){
        Player = GameObject.FindGameObjectWithTag("Player" + this.tag[6]);
        slider = GameObject.FindGameObjectWithTag("health" + tag[6]);
        slider.GetComponentInChildren<Slider>().value = Player.GetComponent<customCharController>().currentHealth;
    }
    
}
