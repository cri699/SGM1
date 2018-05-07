









using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private float attackRate = 1f;
    private float canAttack = 0;
    private bool repeating = true;
    private bool isCausingDamage;

    public float rayRange;
    [SerializeField] private int damage;
    [SerializeField] private float hitDelay;
    [SerializeField] private float damageRepeatRate = 1f;
    [SerializeField] private LayerMask myLayerMask;
    private bool restartCoroutine = false;

    private GameObject[] goWithTag;
    private GameObject mainBase;

    
    private UnityEngine.AI.NavMeshAgent agent;

    private Animator anim;

    private List<customCharController> controllers;

    void Awake()
    {
        controllers = new List<customCharController>();
        goWithTag = GameObject.FindGameObjectsWithTag("Player");
        mainBase = GameObject.FindGameObjectWithTag("Base");
        for (int i = 0; i < goWithTag.Length; i++)
        {
            controllers.Add(goWithTag[i].GetComponent<customCharController>());
        }
        
    }
    // Use this for initialization
    void Start()
    {
        
        
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        anim = GetComponent<Animator>();
        agent.SetDestination(mainBase.transform.position);
     
    }

    void OnTriggerEnter(Collider col)
    {
        
        isCausingDamage = true;
        if(col.transform.tag == "Player")
        {
            customCharController player = col.transform.GetComponent<customCharController>();
            if (player != null && player.isDead != true)
            {
                if (repeating)
                {
                    StartCoroutine(TakeDamage(player, damageRepeatRate));
                }
                else
                {
                    player.TakeDamge(damage);
                }
            }
        }
         if(col.transform.tag  == "tent")
        {
            Debug.Log("I have collided with the tent");
            BaseScript baseScript = col.transform.GetComponentInParent<BaseScript>();
            if(baseScript != null && baseScript.isDestroyed != true)
            {
                agent.SetDestination(transform.position);
                anim.SetBool("run", false);
                if (repeating)
                {
                    StartCoroutine(TakeDamage(baseScript, damageRepeatRate));
                }
                else
                {
                    baseScript.TakeDamage(damage);
                }
            }
        }
        
        
        
    }

    void OnTriggerStay(Collider col)
    {
        customCharController player = col.transform.GetComponent<customCharController>();
        if(player != null && player.isDead == true)
        {
            agent.SetDestination(mainBase.transform.position);
        }

    }

    void OnTriggerExit(Collider col)
    {
        StopAllCoroutines();
        if (col.tag == "Player")
        {
            customCharController player = col.transform.GetComponent<customCharController>();
            if (player != null && player.isDead != true)
            {
                isCausingDamage = false;
            }

            if (col.tag == "tent")
            {
                isCausingDamage = false;
            }
        }
        agent.SetDestination(mainBase.transform.position);
        if(col.transform.tag == "tent")
        {
            BaseScript baseScript = col.transform.GetComponent<BaseScript>();
            if(baseScript != null)
            {
                isCausingDamage = false;
            }
        }
    }
    IEnumerator TakeDamage(customCharController controller, float damageRepeatRate)
    {
        while (isCausingDamage && controller.isDead != true && restartCoroutine == true)
        {
            anim.SetTrigger("attack_1");
            yield return new WaitForSeconds(hitDelay);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
            {
                hit.transform.GetComponent<customCharController>().TakeDamge(damage);
            }
            TakeDamage(controller, damageRepeatRate);
            yield return new WaitForSeconds(damageRepeatRate);
            
        }
        
    }

    IEnumerator TakeDamage(BaseScript baseScript, float damageRepeatRate)
    {
        while (isCausingDamage && baseScript.isDestroyed != true)
        {
            anim.SetTrigger("attack_1");
            yield return new WaitForSeconds(hitDelay);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
            {
                hit.transform.GetComponentInParent<BaseScript>().TakeDamage(damage);
            }
            TakeDamage(baseScript, damageRepeatRate);
            yield return new WaitForSeconds(damageRepeatRate);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        enemyAttack(50, 2.5f);
    }


    public void enemyAttack(float range, float range2)
    {

        for (int i = 0; i < goWithTag.Length; i++)
        {
            
                if ((goWithTag[i].transform.position - this.gameObject.transform.position).sqrMagnitude < range && goWithTag[i].GetComponent<customCharController>().isDead != true)
                {
                    agent.SetDestination(goWithTag[i].transform.position);
                    anim.SetBool("run", true);

                if ((goWithTag[i].transform.position - this.gameObject.transform.position).sqrMagnitude < range2)
                {

                    agent.SetDestination(transform.position);
                    this.transform.LookAt(goWithTag[i].transform);
                    anim.SetBool("run", false);

                }

            }
            // if((goWithTag[i].transform.position - this.gameObject.transform.position).sqrMagnitude > range)
            //if (goWithTag[i].GetComponent<customCharController>().isDead == true)
            else 
                {
                    agent.SetDestination(mainBase.transform.position);
                    anim.SetBool("run", true);
                    if ((mainBase.transform.position - this.gameObject.transform.position).sqrMagnitude < 12f)
                    {
                        this.transform.LookAt(mainBase.transform.position);
                        agent.SetDestination(transform.position);
                        anim.SetBool("run", false);
                    }
                }
            
            

        }
    }

    //RAUL




    //


    //IEnumerator HitDelay()
    //{
    //    anim.SetTrigger("attack_1");
    //    yield return new WaitForSeconds(hitDelay);




    //    RaycastHit hit;
    //    Debug.DrawRay(transform.position, transform.forward * rayRange, Color.green, 0.1f);

    //    if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
    //    {
    //        customCharController cc = hit.transform.GetComponent<customCharController>();

    //        if (cc != null)
    //        {
    //            cc.TakeDamge(damage);
    //        }


    //    }
    //    canAttack = Time.time + attackRate;
    //}
}
