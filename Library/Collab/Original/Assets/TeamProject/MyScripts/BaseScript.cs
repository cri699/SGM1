using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

   
    public HUDScript Hud;


    private void OnTriggerEnter(Collider other)
    {
        

        Hud.OpenMessagePanel();

        /*customCharController player = other.GetComponent<customCharController>();
        if (player != null)
        {
            Debug.Log("CIAO");
            Hud.OpenMessagePanel();
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("CIAO USCITO");
        Hud.CloseMessagePanel();

       /* customCharController item = other.GetComponent<customCharController>();
        if (item != null)
        {
            Debug.Log("CIAO USCITO");
            Hud.CloseMessagePanel();  
        }*/
    }

 
}
