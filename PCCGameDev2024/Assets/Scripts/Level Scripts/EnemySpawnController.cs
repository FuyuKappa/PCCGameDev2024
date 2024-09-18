using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private LevelController lc;

    private GameObject enemy;
    private float spawnTimer;
    private float lastSpawn;

    void Start(){
        spawnTimer = 0f;
        lastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawn >= spawnTimer && lc.GetSpawnedEnemies() < lc.GetEnemyCount()){
            enemy = Instantiate(enemyPrefab, transform);
            enemy.transform.SetParent(null);
            enemy.GetComponent<EnemyStats>().GenerateStats((int)Random.Range(0,3) + 1);
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();

            agent.destination =  GameObject.Find("Player").transform.position;

            spawnTimer = Random.Range(0.5f, 3f);
            lastSpawn = Time.time;
            lc.IncrementSpawnedEnemies();
        }
    }
}
