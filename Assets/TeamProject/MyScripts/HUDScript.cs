using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public List<GameObject> messagesPanelPlayer = new List<GameObject>();
    public GameObject Player1MessagePanel;
    public GameObject Player2MessagePanel;
    public GameObject Player3MessagePanel;
    public GameObject Player4MessagePanel;

    public InventoryPlayer Player1Inventory;
    public InventoryPlayer Player2Inventory;
    public InventoryPlayer Player3Inventory;
    public InventoryPlayer Player4Inventory;

    private bool mIsMessagePanelOpened = false;

    private void Start()
    {
        messagesPanelPlayer.Add(Player1MessagePanel);
        messagesPanelPlayer.Add(Player2MessagePanel);
        messagesPanelPlayer.Add(Player3MessagePanel);
        messagesPanelPlayer.Add(Player4MessagePanel);

        Player1Inventory.ItemAdded += InventoryScript_ItemAdded;
        Player2Inventory.ItemAdded += InventoryScript_ItemAdded;
        Player3Inventory.ItemAdded += InventoryScript_ItemAdded;
        Player4Inventory.ItemAdded += InventoryScript_ItemAdded;

        Player1Inventory.ItemRemoved += InventoryScript_ItemRemoved;
        Player2Inventory.ItemRemoved += InventoryScript_ItemRemoved;
        Player3Inventory.ItemRemoved += InventoryScript_ItemRemoved;
        Player4Inventory.ItemRemoved += InventoryScript_ItemRemoved;

    }

    private void InventoryScript_ItemAdded(object sender, InventoryPlayerEventArgs e)
    {
        //Debug.Log("Item preso");
        //Debug.Log("GG : "+ e.NameInventory);
        //string gg = sender;
        //GameObject inventoryPanel = GameObject.Find(e.NameInventory);
        Transform inventoryPanel = GameObject.Find(e.NameInventory).transform;
        //InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();
        //Debug.Log(e.NameInventory);
        //Debug.Log("Name:");
        Debug.Log(inventoryPanel.gameObject.name+ "OL");
        if(inventoryPanel is Transform)
        {
            
            Debug.Log(e.NameInventory + "FOUND");
            foreach (Transform slot in inventoryPanel)
            {
                Debug.Log("SLOT:");
                Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
                Slot _slot = slot.GetComponent<Slot>();
                //if (_slot.NameSlot == e.Item.Name)
                //{
                //    _slot.counter++;
                //}
                if(!image.enabled)
                {
                    image.enabled = true;
                    image.sprite = e.Item.Image;
                    //_slot.NameSlot = e.Item.Name;
                    //_slot.counter++;
                    //Debug.Log(e.Item.Name.ToString());
                    break;
                }

            }
        }
        
    }

    private void InventoryScript_ItemRemoved(object sender, InventoryPlayerEventArgs e)
    {
        //Debug.Log("Item preso");
        //Debug.Log("GG : " + e.NameInventory);
        //string gg = sender;
        Transform inventoryPanel = GameObject.Find(e.NameInventory).transform;
        //InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        foreach (Transform slot in inventoryPanel)
        {

            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            Slot _slot = slot.GetComponent<Slot>();
            //if (_slot.NameSlot == e.Item.Name)
            //{
                image.enabled = false;
                image.sprite = null;
            //}
            
            //if (image.enabled)
            //{
            //    image.enabled = false;
            //    image.sprite = null;
                
            //    break;
            //}

        }
    }
    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

    public void OpenMessagePanel(customCharController player, string gameText)
    {

        GameObject mPannel = findCurrentPanelByPlayer(player);
        if (mPannel != null)
        {
            mPannel.SetActive(true);

            Text mpText = mPannel.transform.Find("Text").GetComponent<Text>();
            mpText.text = gameText;


            mIsMessagePanelOpened = true;
        }



    }

    public void CloseMessagePanel(customCharController player)
    {
        GameObject mPannel = findCurrentPanelByPlayer(player);
        if (mPannel != null)
        {
            mPannel.SetActive(false);
            mIsMessagePanelOpened = false;
        }

    }

    private GameObject findCurrentPanelByPlayer(customCharController player)
    {
       if (player.tag == "Player1")
            return Player1MessagePanel;
        if (player.tag == "Player2")
            return Player2MessagePanel;
        if (player.tag == "Player3")
            return Player3MessagePanel;
        if (player.tag == "Player4")
            return Player4MessagePanel;
        return null;
        
    }
}
