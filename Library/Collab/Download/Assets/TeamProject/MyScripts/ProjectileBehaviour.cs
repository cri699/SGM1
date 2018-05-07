using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]
    private float damage;

    void Start()
    {
        
        Destroy(this.gameObject, 0.5f);
    }
    void Update()
    {
        if (enemy != null)
        {
            this.transform.LookAt(enemy.transform);
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * 50f);
            
            
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "enemyCollider")
        {
            if(col.gameObject != null && enemy !=null)
            {

                enemy.GetComponent<EnemyController>().TakeDamage(damage);
                
            }
            
        }
    }
}
