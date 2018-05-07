using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    
    public bool isColliding;
    void Start()
    {
        
    }
	void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "enemy")
        Debug.Log(col.transform.tag);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "enemy")
            isColliding = true;
    }
    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "enemy")
            isColliding = false;
    }
}
