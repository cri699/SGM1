using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
    [SerializeField] private GameObject[] players;
    public int playerNumber;
    [SerializeField] private Text text;
    private bool isAxisInUse = false;

    // Use this for initialization
    void OnEnable () {
        playerNumber = 1;
        text.text = "Number of Characters:\n " + (playerNumber);

        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }
	}
	void CharacterSelection()
    {
        switch (playerNumber)
        {
            case 1:
                players[0].SetActive(false);
                players[1].SetActive(false);
                players[2].SetActive(false);
                text.text = "Number of Characters:\n " + (playerNumber);
                break;
            case 2:
                players[0].SetActive(true);
                players[1].SetActive(false);
                players[2].SetActive(false);
                text.text = "Number of Characters:\n " + (playerNumber);

                break;
            case 3:
                players[0].SetActive(true);
                players[1].SetActive(true);
                players[2].SetActive(false);
                text.text = "Number of Characters:\n " + (playerNumber);
                break;
            case 4:
                players[0].SetActive(true);
                players[1].SetActive(true);
                players[2].SetActive(true);
                text.text = "Number of Characters:\n " + (playerNumber);
                break;
            default:
                break;
        }
        


    }
	// Update is called once per frame
	void Update () {
        SelectionControl();
        CharacterSelection();
        Debug.Log(playerNumber);
		
         
        }
        
        
    void SelectionControl()
    {
        if (Input.GetKeyDown(KeyCode.D) 
            || Input.GetKeyDown(KeyCode.Joystick1Button15) 
            || Input.GetKeyDown(KeyCode.Joystick1Button10)
            ||Input.GetAxis("HorizontalJ1") > 0)
        {
            

            if (playerNumber < 4 && isAxisInUse == false)
            {
                playerNumber++;
                
            }

            isAxisInUse = true;
        }

        if (Input.GetKeyDown(KeyCode.A) 
            || Input.GetKeyDown(KeyCode.Joystick1Button14) 
            || Input.GetKeyDown(KeyCode.Joystick1Button9)
            || Input.GetAxis("HorizontalJ1") < 0)
        {
            if (playerNumber > 1 && isAxisInUse == false)
            {
                
                playerNumber--;
            }
            isAxisInUse = true;
        }
        if(Input.GetAxis("HorizontalJ1") == 0)
        {
            isAxisInUse = false;
        }
    }
    }

