using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingMechanic : MonoBehaviour {

    
    [SerializeField] private float hitDelay;
    [SerializeField] private LayerMask myLayerMask;

    private float attackRate = 1f;
    private float canAttack = 0;
    public float rayRange;
    private Animator anim;

    private AudioSource source;
    private CustomAudioManager amscript;

    // Use this for initialization
    void Start () {
        GetComponent<customCharController>().OnAttack += HandleAttack;
        anim = GetComponent<Animator>();

        source = GetComponent<AudioSource>();
        amscript = GameObject.Find("AudioManagerCust").GetComponent<CustomAudioManager>();
    }

    void HandleAttack()
    {
        if (Time.time > canAttack)
        {
            if (Input.GetAxis("FireJ"+this.tag[6]) < 0 || Input.GetButtonDown("FireK"))
            {
                amscript.playAttack(source);//audio
                Debug.Log("FireJ" + this.tag[6]);
                anim.SetTrigger("attack_1");
                canAttack = Time.time + attackRate;
                StartCoroutine(HitDelay());

            }
        }
    }

    IEnumerator HitDelay()
    {
        
        yield return new WaitForSeconds(hitDelay);
        this.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(hitDelay-0.3f);
        this.transform.GetChild(2).gameObject.SetActive(false);

    }
}

