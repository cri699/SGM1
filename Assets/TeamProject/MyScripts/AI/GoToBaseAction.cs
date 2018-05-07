using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBaseAction : TreeAction {
    private GameObject mainBase;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;

    

    // Use this for initialization
    void Start () {
        mainBase = GameObject.FindGameObjectWithTag("Base");
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInParent<Animator>();
    }
    public override void performAction()
    {
        agent.SetDestination(mainBase.transform.position);
        anim.SetBool("run", true);
    }

    public override string actionName()
    {
        return "Going to base";
    }
}
