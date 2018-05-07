using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFacingPlayer : Condition {
    private GameObject pursuedPlayer;

    protected override bool isValid()
    {
        
        pursuedPlayer = GetComponentInParent<CanSeePlayer>().pursuedPlayers[0];
        if(pursuedPlayer != null)
        {
            float angle = 10;
            return (Vector3.Angle(pursuedPlayer.transform.right, transform.position - pursuedPlayer.transform.position) < angle);
           

        }
        return false;
       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
