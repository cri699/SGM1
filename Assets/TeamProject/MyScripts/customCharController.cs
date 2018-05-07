using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class customCharController : MonoBehaviour {

    public int currentHealth;
    private int maxHealth = 100;
    public bool isDead;
    public bool isPursued = false;

    

    public event Action OnTowerPlacementMechanicActive = delegate { };
    public event Action<int> OnHPpctsChanged = delegate { };
    public event Action OnAttack = delegate { };
    public event Action OnMovement = delegate { };
    public event Action OnDie = delegate { };
    public event Action OnSeedPlant = delegate { };
    //public event Action OnBeingPursued = delegate { };
    
    public InventoryPlayer Inventory;





    // Use this for initialization
    void Start () {
        isDead = false;
        
       // currentHealth = maxHealth;
    }

    //ANSWERS ABOUT DIFFERENT UPDATE TYPES

    //    This is a confusing and often misunderstood area.As a general rule:
    //Input should be in Update(), so that there is no chance of having a frame in which you miss the player input (which could happen if you placed it in FixedUpdate(), say).
    //Physics calculations should be in FixedUpdate(), so that they are consistent and synchronised with the global physics timestep of the game(by default 50 times per second).
    //Camera movement should be in LateUpdate(), so that it reflects the positions of any objects that may have moved in the current frame.
    //However, there are always exceptions to these, and some experimentation may be required to get what works for you in a given scenario.
    //Change1


    void Update()
    {
        if(isDead != true)
        {
            OnTowerPlacementMechanicActive();
            OnAttack();
            
           // OnSeedPlant();
           
        }
        
        
    }
    

    

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (isDead != true)
        {
            OnMovement();
        }
    }

    public void TakeDamge(int damage)
    {
        if(isDead != true)
        {
            OnHPpctsChanged(damage);
            if (currentHealth <= 0)
            {
                
            
                OnDie();
                isDead = true;
            }
        }
        
    }
    

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponentInChildren<CanSeePlayer>() != null && col.transform.tag == "enemy" && this.isDead == false)
        {
            isPursued = true;
            if (!col.GetComponentInChildren<CanSeePlayer>().pursuedPlayers.Contains(this.gameObject))
            {
                col.GetComponentInChildren<CanSeePlayer>().pursuedPlayers.Add(this.gameObject);
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if(col.transform.tag == "enemy" && this.isDead == true)
        {
            isPursued = false;
            if(col.GetComponent<EnemyController>().isDead != true)
            {
            col.GetComponentInChildren<CanSeePlayer>().pursuedPlayers.Remove(this.gameObject);
            }

        }
        if(col.transform.tag == "enemy" && this.isDead != true)
        {
            isPursued = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "enemy" && this.isDead == false)
        {
            isPursued = false;
            if(col.GetComponentInChildren<CanSeePlayer>() != null && col.GetComponentInChildren<CanSeePlayer>().pursuedPlayers.Contains(this.gameObject))
            col.GetComponentInChildren<CanSeePlayer>().pursuedPlayers.Remove(this.gameObject);
        }
    }

    public void addItemPlayer(Item item)
    {
        //Debug.Log(coll.gameObject.name);
        //IItem item = coll.collider.GetComponent<IItem>();

        if (item != null)
        {
            Debug.Log("somethignhere");
            Inventory.AddItem(item);
        }
    }
}

