using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string Name;

    public Sprite Image;
    public string InteractText = "Press B to pickup the item";
    public bool IsConsumable;
    public HUDScript Hud;
    

    public virtual void OnPickup()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        customCharController player = other.GetComponent<customCharController>();

        if (player != null)
        {
            //OnPickup();
            player.addItemPlayer(this);
            //Hud.OpenMessagePanel(player, InteractText);
        }
        /*customCharController player = other.GetComponent<customCharController>();
        */
    }

    //private void OnTriggerExit(Collider other)
    //{

    //    GameObject player = other.gameObject;
    //    //customCharController item = other.GetComponent<customCharController>();
    //    if (player != null)
    //    {
    //        //Debug.Log("CIAO USCITO");
    //        Hud.CloseMessagePanel(player);
    //    }
    //}

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
