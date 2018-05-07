using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

    public int hitPoints;
    public bool isDestroyed;
    private int maxHitPoints = 100;
    public HUDScript Hud;
    public string InteractText = "Press F to drop resources";
    public Transform myPos;

    void Start()
    {
        myPos = transform.transform;
        isDestroyed = false;
        hitPoints = maxHitPoints;
    }

    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject;
        //GameObject player = other.gameObject;
        customCharController player = other.GetComponent<customCharController>();

        if (player != null)
        {

            Hud.OpenMessagePanel(player, InteractText);
        }
        /*customCharController player = other.GetComponent<customCharController>();
        */
    }

    private void OnTriggerExit(Collider other)
    {

        //GameObject player = other.gameObject;
        customCharController player = other.GetComponent<customCharController>();
        if (player != null)
        {
            
            Hud.CloseMessagePanel(player);
        }
    }

    public void TakeDamage(int amount)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
        {
            this.gameObject.SetActive(false);
            isDestroyed = true;
        }
    }

 
}
