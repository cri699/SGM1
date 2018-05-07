using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : Condition {
    
    [SerializeField] private float range = 50f;
    public List<GameObject> pursuedPlayers;
    

    protected override bool isValid()
    {
        
        if (pursuedPlayers.Count > 0)
        {
            customCharController playerController = pursuedPlayers[0].GetComponent<customCharController>();
            return playerController.isPursued && playerController.isDead != true;
        }
        return false;
    }



    // Use this for initialization
    // Update is called once per frame
	void Update () {
		
	}
}
