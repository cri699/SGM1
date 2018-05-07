using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health2Script : MonoBehaviour {


	public Slider healthSlider;
	public GameObject Player;
	// Use this for initialization
	void Awake () {
		healthSlider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	public void AdjustSlider(int damage){
		healthSlider.value -=damage;
	}

}
