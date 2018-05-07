using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public GameObject BaseMessagePanel;
    private bool mIsMessagePanelOpened = false;
    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

    public void OpenMessagePanel()
    {
        Debug.Log("CIAO");
        BaseMessagePanel.SetActive(true);

        Text mpText = BaseMessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = "Press A";


        mIsMessagePanelOpened = true;


    }

    public void CloseMessagePanel()
    {
        BaseMessagePanel.SetActive(false);

        mIsMessagePanelOpened = false;
    }
}
