using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    EnemyManager em;
	// Use this for initialization
	void Start () {
        em = new EnemyManager();
	}
	
	// Update is called once per frame
	void Update () {
        em.Spawn();
	}
}
