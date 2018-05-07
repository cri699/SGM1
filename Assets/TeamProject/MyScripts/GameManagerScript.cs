using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    private int playerNumber;
    [SerializeField] private GameObject[] players;
    [SerializeField] private Transform[] playersPositions;
    [SerializeField] private PlayersFollow cameraScript;

    public EnemyManager em;
	// Use this for initialization
	void Awake () {
       
        playerNumber = PlayerPrefs.GetInt("NumberOfPlayers");
        
        for (int i = 0; i < playerNumber; i++)
        {
            Instantiate(players[i], playersPositions[i].transform.position, playersPositions[i].transform.rotation);
            GameObject.FindGameObjectWithTag("health"+(i+1)).GetComponent<HealthScript>().Player = players[i];
            players[i].GetComponent<customCharController>().Inventory = GameObject.FindGameObjectWithTag("inventory" + (i + 1)).GetComponent<InventoryPlayer>();
            
        }
        
        cameraScript.AlignCamera(playerNumber);
        
	}
	
	public void RestartGame()
    {
        Debug.Log(players.Length);
        for (int i = 0; i < players.Length; i++)
        {
            GameObject player;
           player =  GameObject.FindGameObjectWithTag("Player" + (i + 1));
            
            if (player != null)
            {
                player.GetComponent<Animator>().Rebind();
                player.transform.position = playersPositions[i].transform.position;
                players[i].transform.rotation = playersPositions[i].rotation;
                player.GetComponent<customCharController>().currentHealth = 100;
                player.GetComponent<customCharController>().isDead = false;
                player.GetComponent<PlacingTowerMechanic>().enabled = false;
                player.GetComponent<PlacingTowerMechanic>().enabled = true;
            }
            em.Restart();
        }
        
        cameraScript.AlignCamera(playerNumber);
        GameObject[] towers;
        towers = GameObject.FindGameObjectsWithTag("tower");
        for (int i = 0; i < towers.Length; i++)
        {
            Destroy(towers[i]);
        }
    }
}
