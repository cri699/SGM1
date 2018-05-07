using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

   
    public HUDScript Hud;


    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject;
        GameObject player = other.gameObject;
        
        if (player != null)
        {
           
            Hud.OpenMessagePanel(player);
        }
        /*customCharController player = other.GetComponent<customCharController>();
        */
    }

    private void OnTriggerExit(Collider other)
    {
        
        GameObject player = other.gameObject;
        //customCharController item = other.GetComponent<customCharController>();
        if (player != null)
        {
            //Debug.Log("CIAO USCITO");
            Hud.CloseMessagePanel(player);  
        }
    }

 
}
