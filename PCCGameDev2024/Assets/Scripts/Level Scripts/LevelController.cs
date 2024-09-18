using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int enemyCount;
    private int spawnedEnemies = 0;
    private int enemiesKilled;
    [SerializeField]
    private GameObject levelEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 18;  
    }

    public void IncrementSpawnedEnemies(){
        spawnedEnemies++;
    }

    public int GetSpawnedEnemies(){
        return spawnedEnemies;
    }

    public int GetEnemyCount(){
        return enemyCount;
    }

    public int GetEnemiesKilled(){
        return enemiesKilled;
    }

    public void IncrementKilledEnemies(){
        enemiesKilled++;
    }

    void Update(){
        if(enemiesKilled == enemyCount){
            levelEnd.SetActive(true);
        }
    }
}
