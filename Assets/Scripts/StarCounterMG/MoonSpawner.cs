using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public int numberOfCircles = 10;
    public float circleRadius = 1.0f;


    public List<Vector3> spawnCoordinates;

    public Vector2 minBounds = new Vector2(-20, -20);
    public Vector2 maxBounds = new Vector2(20, 20);

    private List<GameObject> spawnedCircles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnCircles();
    }
    void SpawnCircles()
    {
        for (int i = 0; i < numberOfCircles; i++)
        {
            Vector2 randomPosition;
            bool positionIsValid;

            do
            {
                positionIsValid = true;

                float randomX = Random.Range(minBounds.x, maxBounds.x);
                float randomY = Random.Range(minBounds.y, maxBounds.y);
                randomPosition = new Vector2(randomX, randomY);

                foreach (GameObject existingCirlce in spawnedCircles)
                {
                    float distance = Vector2.Distance(randomPosition, existingCirlce.transform.position);
                    if (distance < circleRadius * 2)
                    {
                        positionIsValid = false;
                        break;
                    }
                }

            }

            while (!positionIsValid);
            GameObject newCircle = Instantiate(circlePrefab, randomPosition, Quaternion.identity);

            newCircle.tag = "ClickableObject";

            spawnedCircles.Add(newCircle);
        }

    }
}
