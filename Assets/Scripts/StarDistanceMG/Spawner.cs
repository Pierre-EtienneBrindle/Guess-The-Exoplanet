using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstaclePrefabs;
    public float obstacleSpawnTime = 2.0f;

    private float timeUntilSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn += Time.deltaTime;
        if (timeUntilSpawn > obstacleSpawnTime)
        {
            timeUntilSpawn = Random.Range(0f, 1.5f);
            Obstacle spawnedObject = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPostition = new(Random.Range(-9.5f, 9.5f), 6f, 0f);
            Obstacle spawnedObstacle = Obstacle.ObstacleCalled(spawnedObject, spawnPostition, Quaternion.Euler(0, 0, Random.Range(0, 360)), Random.Range(0f, 1.5f));
        }
    }
}
