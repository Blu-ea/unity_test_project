using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    
    [Range(0.1f, 12f)]
    public float shootSpeed = 3f;
    private float _shootingDelay;
    private bool _canShoot = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shootingDelay = 1 / shootSpeed;
    }

    IEnumerator Shoot()
    {
        _canShoot = false;
        Instantiate(bullet, transform.position + (transform.up * 2), transform.rotation);
        yield return new WaitForSeconds(_shootingDelay);
        _canShoot = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton((int) MouseButton.Left) && _canShoot )
        {
            StartCoroutine(Shoot());
        }
    }

}
