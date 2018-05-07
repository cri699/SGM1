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

    private bool mIsMessagePanelOpened = false;

    private void Start()
    {
        messagesPanelPlayer.Add(Player1MessagePanel);
        messagesPanelPlayer.Add(Player2MessagePanel);
        messagesPanelPlayer.Add(Player3MessagePanel);
        messagesPanelPlayer.Add(Player4MessagePanel);

    }

    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

    public void OpenMessagePanel(GameObject player)
    {
        
        GameObject mPannel = findCurrentPanelByPlayer(player);

        mPannel.SetActive(true);

        Text mpText = mPannel.transform.Find("Text").GetComponent<Text>();
        mpText.text = "Press A";


        mIsMessagePanelOpened = true;


    }

    public void CloseMessagePanel(GameObject player)
    {
        GameObject mPannel = findCurrentPanelByPlayer(player);
        mPannel.SetActive(false);    
        mIsMessagePanelOpened = false;
    }

    private GameObject findCurrentPanelByPlayer(GameObject player)
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
