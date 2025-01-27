using System;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public float Speed = 1f;
    
    private GameObject Player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position);
        transform.Translate(Vector3.forward * (Speed * Time.deltaTime));
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, 1);
    }
}
