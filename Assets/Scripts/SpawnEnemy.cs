using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnEnemy : MonoBehaviour
{
    
    // public GameObject[] enemyType;

    [SerializedDictionary("Enemy Type", "Spawn Timer")]
    public SerializedDictionary<GameObject, float> spawnTime;
    private bool[] _spawnable; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // for (int i = 0; i < enemyType.Length; i++)
        // {
            // spawnTime.Add(gameObject, Random.Range(4f * i, 6f * i));
            // _spawnable[i] = false;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
