using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTowerMechanic : MonoBehaviour {

    [SerializeField] private float towerPlacingRange;
    [SerializeField] private GameObject tower;
    

    private customCharController controller;
    public bool[] showTower;
    private int index;

    //Tower stuff


    // Use this for initialization
    void OnEnable () {
        
        index = (int)char.GetNumericValue(this.tag[6])-1;
        showTower = new bool[4];
        //int val = (int)Char.GetNumericValue('8');
        Debug.Log(showTower[index]);
        
        controller = GetComponent<customCharController>();
        controller.OnTowerPlacementMechanicActive += HandleTowerPlacementMechanic;

        tower = this.transform.GetChild(3).gameObject;
        tower.GetComponent<TowerBehaviour>().enabled = false;
        tower.SetActive(false);
        
        
    }

    void HandleTowerPlacementMechanic()
    {
        //TOWER PLACING MECHANIC
        
        if (Input.GetButtonDown("BuildMode"+this.transform.tag[6]) && showTower[index] != true || Input.GetButtonDown("BuildModeK"))
        {
            
                Debug.DrawRay(transform.position, transform.forward * towerPlacingRange, Color.green, 10f);
                showTower[index] = true;
            
        }
        if (Input.GetButtonDown("ExitBuildMode" + this.tag[6]) || Input.GetButtonDown("ExitBuildModeK"))
        {
            showTower[index] = false;
            tower.SetActive(false);

        }
        if (showTower[index] == true)
        {
            if(controller.isDead == true)
            {
                tower.SetActive(false);
            }
            tower.transform.position = transform.position + (transform.forward * towerPlacingRange);
            if (tower.activeSelf != true)
            {
                tower.SetActive(true);
            }
            
            if ((Input.GetButtonDown("ConfirmBuild"+this.tag[6]) || Input.GetButtonDown("ConfirmBuildK"))  && tower.GetComponent<TowerBehaviour>().isColliding != true)
            {
                InventoryPlayer inventory = GetComponent<customCharController>().Inventory;
                Item log = inventory.mItems[0];
                //Debug.Log(inventory.mItems.Count + "W");
                if (inventory.mItems.Count >= 3)
                {
                    GameObject placedTower = Instantiate(tower, transform.position + (transform.forward * towerPlacingRange), tower.transform.rotation);
                    tower.SetActive(false);
                    placedTower.GetComponent<TowerBehaviour>().enabled = true;
                    placedTower.SetActive(true);

                    placedTower.GetComponent<TowerBehaviour>().SetOpaque();
                    placedTower.GetComponent<TowerBehaviour>().isPlaced = true;

                    showTower[index] = false;
                    placedTower.transform.tag = "tower";
                    inventory.RemoveAllItems(log);
                }
                

            }
        }
    }
}
