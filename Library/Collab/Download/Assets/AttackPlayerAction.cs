using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerAction : TreeAction {

    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject goWithTag;

    private float attackRate = 1f;
    private bool repeating = true;
    private bool isCausingDamage;
    private bool canAttackFlag = true;

    public float rayRange;
    [SerializeField] private int damage;
    [SerializeField] private float hitDelay;
    [SerializeField] private float damageRepeatRate = 1f;
    private GameObject pursuedPlayer;


    void Start()
    {
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInParent<Animator>();
        
    }

    

    public override string actionName()
    {
        return "Attacking Player";
    }

    public override void performAction()
    {
        pursuedPlayer = GetComponentInParent<CanSeePlayer>().pursuedPlayers[0];
        isCausingDamage = true;
        anim.SetBool("run", false);
        agent.SetDestination(transform.position);
        customCharController controller = pursuedPlayer.GetComponentInParent<customCharController>();
        if (controller != null && controller.isDead != true)
        {
            agent.SetDestination(transform.position);
            
            anim.SetBool("run", false);
            if (canAttackFlag == true)
            {
                StartCoroutine(TakeDamage(controller, damageRepeatRate));

            }
            canAttackFlag = false;
        }

    }

    IEnumerator TakeDamage(customCharController controller, float damageRepeatRate)
    {

        this.transform.LookAt(pursuedPlayer.transform.position);

        canAttackFlag = false;
        yield return new WaitForSeconds(1);  //should be hitdelay

        anim.SetTrigger("attack_1");
        yield return new WaitForSeconds(0.4f);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1.5f)) {
            hit.transform.GetComponent<customCharController>().TakeDamage(damage);
        }
        Debug.Log("this");
        

        TakeDamage(controller, damageRepeatRate);
        yield return new WaitForSeconds(damageRepeatRate);
        canAttackFlag = true;


    }
}
