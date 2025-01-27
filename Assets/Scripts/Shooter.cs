using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton((int) MouseButton.Left))
        {
            var front = transform.forward;
            Instantiate(bullet, transform.position + (transform.up * 2), Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        Gizmos.DrawWireSphere(transform.position + (transform.up * 2), 0.5f);
    }
}
