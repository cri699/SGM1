using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBaseAction : TreeAction {

    private GameObject mainBase;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;

    private float attackRate = 1f;
    
    private bool repeating = true;
    private bool isCausingDamage;

    public float rayRange;
    [SerializeField] private int damage;
    [SerializeField] private float hitDelay;
    [SerializeField] private float damageRepeatRate = 1f;
    private bool canAttackFlag = true;

    void Start()
    {
        mainBase = GameObject.FindGameObjectWithTag("Base");
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInParent<Animator>();
    }

    public override string actionName()
    {
        return "Attacking base";
    }

    public override void performAction()
    {
        isCausingDamage = true;
        anim.SetBool("run", false);
        agent.SetDestination(transform.position);
        
        BaseScript baseScript = mainBase.GetComponent<BaseScript>();
        if (baseScript != null && baseScript.isDestroyed != true)
        {
            agent.SetDestination(transform.position);
            anim.SetBool("run", false);
            if (canAttackFlag == true)
            {
                StartCoroutine(TakeDamage(baseScript, damageRepeatRate));
                
            }
            canAttackFlag = false;
        }

    }

    IEnumerator TakeDamage(BaseScript baseScript, float damageRepeatRate)
    {
            canAttackFlag = false;
            anim.SetTrigger("attack_1");
            yield return new WaitForSeconds(hitDelay);
        //RaycastHit hit;

        mainBase.GetComponent<BaseScript>().TakeDamage(damage);
            
            TakeDamage(baseScript, damageRepeatRate);
            yield return new WaitForSeconds(damageRepeatRate);
        canAttackFlag = true;
        

    }



    // Update is called once per frame
    void Update () {
		
	}
}
