using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstaclePrefabs;
    public float obstacleSpawnTime = 1.5f;
    private float chanceToMultipleSpawns = 0f;
    private float timeUntilSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn += Time.deltaTime;
        Vector3 spawnPostition = new(Random.Range(-9.5f, 9.5f), 6f, -1f);
        if (timeUntilSpawn > obstacleSpawnTime)
        {
            timeUntilSpawn = Random.Range(0.5f, 1.25f);
            if (chanceToMultipleSpawns <= 0.75f)
            {
                chanceToMultipleSpawns += 0.001f;
            }
            else { 
                Obstacle.ObstacleCalled(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPostition, Quaternion.Euler(0, 0, Random.Range(0, 360)), Random.Range(2.5f, 7.5f)); 
            }
            Obstacle.ObstacleCalled(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPostition, Quaternion.Euler(0, 0, Random.Range(0, 360)), Random.Range(2.5f, 7.5f));
            if ((int)Random.Range(0, 5) == 0) Obstacle.ObstacleCalled(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPostition, Quaternion.Euler(0, 0, Random.Range(0, 360)), Random.Range(2.5f, 7.5f));
            if ((int)Random.Range(0, 1f - chanceToMultipleSpawns) == 0) Obstacle.ObstacleCalled(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPostition, Quaternion.Euler(0, 0, Random.Range(0, 360)), Random.Range(2.5f, 7.5f));
        }
    }
}
