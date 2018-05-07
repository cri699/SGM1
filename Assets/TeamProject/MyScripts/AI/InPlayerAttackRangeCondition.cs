using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPlayerAttackRangeCondition : Condition {
    private GameObject pursuedPlayer;
    private float range = 3f;
    // Use this for initialization
    void Start()
    {
        
    }

    

    protected override bool isValid()
    {
        pursuedPlayer = GetComponentInParent<CanSeePlayer>().pursuedPlayers[0];
        if(pursuedPlayer != null)
        {
            return ((pursuedPlayer.transform.position - this.gameObject.transform.position).sqrMagnitude < range && pursuedPlayer.GetComponent<customCharController>().isDead != true);
            
        }
        return false;
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
