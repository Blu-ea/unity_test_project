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

    public int _distance;
    
    private IEnumerator SpawnEnemyCoroutine(GameObject enemy, float spawnTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTime - 3f, spawnTime + 3f));
            float angle = Random.Range(0f, Mathf.PI * 2f);
            var pos = new Vector3(
                _distance * Mathf.Cos(angle),
                _distance * Mathf.Sin(angle)
            );
            transform.position = transform.parent.position + pos;
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1);
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
    }
}
