using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public float speed = 1f;
    public int power = 4;
    public int health = 10;
    
    private GameObject _player;
    private Rigidbody2D _rb2d;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform.position);
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        _rb2d.linearVelocity = Vector2.zero;
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            var bullet = collision.gameObject.GetComponent<BulletBehaviour>();
            bullet.Hit();
            takeDamage(bullet.damages);
        }
    }

    void takeDamage(int damages)
    {
        health -= damages;
        if (health <= 0)
            Destroy(gameObject);
    }
}
