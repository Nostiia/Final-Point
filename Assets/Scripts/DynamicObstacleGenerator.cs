using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacleGenerator : MonoBehaviour
{
    // Define the obstacle prefab as an attribute
    public GameObject obstaclePrefab;

    // Define the number of obstacles to instantiate
    public int numberOfObstacles = 5;

    // Define the center position for obstacle instantiation
    public Vector3 centerPosition = new Vector3(642f, 39f, 584f);

    // Define the range of variation around the center position
    public float positionVariation = 100f;

    void Start()
    {
        // Instantiate obstacles
        for (int i = 0; i < numberOfObstacles; i++)
        {
            // Generate random position near the center position
            Vector3 spawnPosition = centerPosition + new Vector3(Random.Range(-positionVariation, positionVariation),
                                                                 0.5f,
                                                                 Random.Range(-positionVariation, positionVariation));

            // Instantiate obstacle at the spawn position
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
