using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    
    // public GameObject[] enemyType;

    [FormerlySerializedAs("spawnTime")] [SerializedDictionary("Enemy Type", "Spawn Timer +- 3s")]
    public SerializedDictionary<GameObject, float> allEnemy;

    private Vector3 _spawnRange;
    private IEnumerator SpawnEnemyCoroutine(GameObject enemy, float spawnTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTime - 3f, spawnTime + 3f));
            Instantiate(enemy, _spawnRange, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_spawnRange, 1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        foreach (var enemy in allEnemy)
        {
            StartCoroutine(SpawnEnemyCoroutine(enemy.Key, enemy.Value));
        }
    }

    
    // Update is called once per frame
    private void Update()
    {
        // var isNeggative = Random.Range(0, 2) * 2 - 1;
        _spawnRange = new Vector3(
            Random.Range(5, 10) * (Random.Range(0, 2) * 2 - 1) + transform.position.x,
            Random.Range(5, 10) * (Random.Range(0, 2) * 2 - 1) + transform.position.y,
            0F);

    }
}
