using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public int spawnCount = 5;
    public float spawnOffset = 1.5f;

    void Start() {
        if (spawnPrefab != null)
        {            
            SpawnEnemies();    
        }else
        {
            Debug.LogError("Prefab is missing");
        }
    }

    void SpawnEnemies()
    {

    }
}
