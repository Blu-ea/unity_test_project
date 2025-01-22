using UnityEngine;

public class EnemyPower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public int power = 4;

    public int health = 10;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
