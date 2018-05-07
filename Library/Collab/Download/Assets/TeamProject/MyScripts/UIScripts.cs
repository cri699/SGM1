using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour {

    public GameObject firstButton;
    [SerializeField] private CharacterSelector cs;

    void OnEnable()
    {

        EventSystem.current.firstSelectedGameObject = firstButton;
        EventSystem.current.SetSelectedGameObject(firstButton);


    }

    public void StartGame()
    {

        PlayerPrefs.SetInt("NumberOfPlayers", cs.playerNumber);
        SceneManager.LoadScene("VladScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
