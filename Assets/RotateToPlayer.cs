using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : TreeAction {
    private GameObject pursuedPlayer;

    public override string actionName()
    {
        return "Rotating to player";
    }

    public override void performAction()
    {
        pursuedPlayer = GetComponentInParent<CanSeePlayer>().pursuedPlayers[0];
        if(pursuedPlayer != null)
        {
            var lookPos = pursuedPlayer.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 30f);
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
