using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 1f;

    private GameObject _player;

    private Vector2 _residual_velocity;
    private Vector3 _velocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _residual_velocity = _player.GetComponent<Rigidbody2D>().linearVelocity;
        
        _velocity = ((transform.up) * bulletSpeed) + _residual_velocity.ConvertTo<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_velocity * Time.deltaTime, Space.World);
    }
}
