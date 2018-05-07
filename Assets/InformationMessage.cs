using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationMessage : MonoBehaviour {
    private static Text text;
    private float displayTime = 3f;
    public static InformationMessage instace;
	// Use this for initialization
	void Awake () {
        if(instace == null)
        {
            instace = this;
        }
        if(text == null)
        {
            text = GetComponentInChildren<Text>();
        }
        
       
	}
	
	public void DisplayMessage(string message)
    {

        text.text = message;
        
        
        StartCoroutine(MessageDisplayTime());
    }
    IEnumerator MessageDisplayTime()
    {
        yield return new WaitForSeconds(3f);
        text.text = "";
    }
}
