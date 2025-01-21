using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float movSpeed = 1f;
    public int health = 100; 
    public float iTime = 3;

    private float _xSpeed, _ySpeed;
    Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _xSpeed = Input.GetAxis("Horizontal") * movSpeed;
        _ySpeed = Input.GetAxis("Vertical") * movSpeed;
        rb2d.linearVelocity = new Vector2(_xSpeed, _ySpeed);
    }

    IEnumerator IFrame()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(iTime);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= collision.gameObject.GetComponent<EnemyPower>().power;
            StartCoroutine(IFrame());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (Physics2D.GetIgnoreLayerCollision(6, 7))
            Gizmos.DrawWireSphere(transform.position, 1);
    }
}
