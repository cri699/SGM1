using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour {
    [SerializeField] private float damage;
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "enemyCollider")
        {
            col.GetComponentInParent<EnemyController>().TakeDamage(damage);
        }
        if(col.transform.tag == "tree")
        {
            col.GetComponent<Target>().TakeDamage(damage);
        }
            

            
    }
}
