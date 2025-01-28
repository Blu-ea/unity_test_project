using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 1f;
    public float bulletLifeTime = 30f;

    public int maxHitCount = 1;
    private int _currentHitCount = 0;
    public int damages = 1;

    private GameObject _player;

    private Vector2 _residualVelocity;
    private Vector3 _velocity;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _residualVelocity = _player.GetComponent<Rigidbody2D>().linearVelocity;
        _velocity = ((transform.up) * bulletSpeed) + _residualVelocity.ConvertTo<Vector3>();

        StartCoroutine(Lifetime());
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(_velocity * Time.deltaTime, Space.World);
    }

    public void Hit()
    {
        _currentHitCount++;
        if (_currentHitCount >= maxHitCount)
            Destroy(gameObject);
    }
}
