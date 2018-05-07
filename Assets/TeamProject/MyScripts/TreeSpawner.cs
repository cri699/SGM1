using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    int index;
    public ArrayList seeds;
    private float canAttack = 0;
    private System.Boolean canPlant = true;
    // Use this for initialization
    void Start()
    {
        index = 0;
        GetComponent<customCharController>().OnSeedPlant += treeSpawn;
        seeds = new ArrayList();


    }



    public void treeSpawn()
    {
        if (Time.time > canAttack)
        {
            if (Input.GetAxis("FireJ" + this.tag[6]) < 0)  // && the inventory has seed
            {

                //seeds-1
                GameObject seed = (GameObject)(Instantiate(Resources.Load("seed"), this.transform.position, Quaternion.identity));

                seeds.Add(seed);
                Debug.Log("aaaaaaaaaa");

                canAttack = Time.time + 1;
                StartCoroutine(weit());

                StartCoroutine(treeProcessing(index));
                index++;

            }
        }



    }

    IEnumerator weit()
    {
        yield return new WaitForSeconds(1);

    }
    IEnumerator treeProcessing(int index)
    {
        yield return new WaitForSeconds(3);

        int i = Random.Range(1, 4);
        if (i == 1)
        {
            GameObject temp = (GameObject)seeds[index];
            Instantiate(Resources.Load("Tree1"), temp.transform.position, Quaternion.identity);
            dest(index);
        }
        else if (i == 2)
        {
            GameObject temp = (GameObject)seeds[index];
            Instantiate(Resources.Load("Tree2"), temp.transform.position, Quaternion.identity);
            dest(index);
        }
        else
        {
            GameObject temp = (GameObject)seeds[index];
            Instantiate(Resources.Load("Tree3"), temp.transform.position, Quaternion.identity);
            dest(index);
        }
    }

    public void dest(int index)
    {
        Destroy((GameObject)seeds[index]);
        seeds.Remove(index);
    }
}
