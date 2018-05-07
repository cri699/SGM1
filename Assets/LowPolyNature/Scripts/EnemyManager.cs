using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    //public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    private int waveCount;
   
    public static float enemyCount = 0;
    [SerializeField]
    private static int deathCount;
    public float spawnTime = 3f;            // How long between each spawn.
    public static bool canSpawn = true;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    private InformationMessage im;

    

    void OnEnable()
    {
        im = GameObject.FindGameObjectWithTag("message").GetComponent<InformationMessage>();
        enemyCount = 2;
        deathCount = 0;
        waveCount = 1;
        canSpawn = true;
        

    }

    public void Restart()
    {
        canSpawn = false;
        enemyCount = 2;
        deathCount = 0;
        waveCount = 1;
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
        canSpawn = true;
    }
    void Update()
    {
        if(canSpawn == true)
        {
            Debug.Log(enemyCount);
            NewWave(enemyCount);
            canSpawn = false;
        }

        
    }

    public float GetDeadEnemies()
    {
        return deathCount;
    }
    public void RegisterDeath()
    {
        deathCount++;
        Debug.Log("Current number of  DEAD enemies" + GetDeadEnemies());
        Debug.Log("total number of enemies spawned" + enemyCount);
        if (deathCount == enemyCount)
        {
            Debug.Log("Do I get here???");
            enemyCount = enemyCount + (enemyCount * 0.5f);
            int rounded = Convert.ToInt32(enemyCount);
            enemyCount = rounded;
            Debug.Log(enemyCount + " AFTER ROUNDING");
            deathCount = 0;
            canSpawn = true;
            

        }
    }
    
    private void NewWave(float enemyCount)
    {
        
        for (int i = 0; i < enemyCount; i++)
        {
            int randSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
            float randSpawnTime = UnityEngine.Random.Range(1f, 4f);
            StartCoroutine(SpawnEnemy(randSpawnPoint, randSpawnTime));
         }
        im.DisplayMessage("Wave " + waveCount);

        waveCount++;
        
        
    }
    IEnumerator SpawnEnemy(int randLoc, float randTime)
    {
        yield return new WaitForSeconds(randTime);
        Instantiate(enemy, spawnPoints[randLoc].position, Quaternion.identity);
    }
}