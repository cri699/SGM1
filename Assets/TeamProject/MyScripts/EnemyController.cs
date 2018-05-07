using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float health;
    private float maxHealth = 40;
    public EnemyManager em;

    public bool isDead;

    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;

    private ParticleSystem _psystem;

    private AudioSource source;
    private CustomAudioManager amscript;

    void Awake()
    {
        _psystem = GetComponent<ParticleSystem>();
    }
    // Use this for initialization
    void Start () {
        health = maxHealth;
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInParent<Animator>();

        source = GetComponent<AudioSource>();
        amscript = GameObject.Find("AudioManagerCust").GetComponent<CustomAudioManager>();
    }
	
    public void TakeDamage(float amount)
    {
        amscript.playCutSounds(source);//audio
        health -= amount;
        if(health <= 0 && isDead != true)
        {
            
            Die();
            isDead = true;
            em.RegisterDeath();
            
        }
        _psystem.Play();
    }
    void Die()
    {
        amscript.playDie(source);//audio
        anim.SetTrigger("death");
        this.transform.GetChild(2).gameObject.SetActive(false);
        agent.SetDestination(this.transform.position);
        Destroy(this.gameObject, 2f);
    }



	
}
