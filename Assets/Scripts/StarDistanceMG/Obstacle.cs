using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected float speed;

    public static Obstacle ObstacleCalled(Obstacle prefab, Vector3 pos, Quaternion rot, float speed)
    {
        Obstacle spawnedComet = Instantiate(prefab, pos, rot);
        spawnedComet.speed = speed;
        return spawnedComet;
    }
}
