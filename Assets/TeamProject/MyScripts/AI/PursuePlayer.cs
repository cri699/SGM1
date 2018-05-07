using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuePlayer : TreeAction {

    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject pursuedPlayer;
    
    // Use this for initialization
    void Start()
    {
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInParent<Animator>();
        
    }


    public override string actionName()
    {
        return "Pursuing Player";
    }

    public override void performAction()
    {
        pursuedPlayer = GetComponentInParent<CanSeePlayer>().pursuedPlayers[0];
        if (pursuedPlayer != null)
        {
            agent.SetDestination(pursuedPlayer.transform.position);
            anim.SetBool("run", true);

        }

    }
}
