using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBaseAttackRangeCondition : Condition {

    private GameObject mainBase;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        mainBase = GameObject.FindGameObjectWithTag("Base");
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInParent<Animator>();
    }


    protected override bool isValid()
    {
        anim.SetBool("run", false);
        
        return ((mainBase.transform.position - this.gameObject.transform.position).sqrMagnitude < 12f);
    }
    
}
