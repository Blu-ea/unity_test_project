using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float movSpeed = 1f;
    public int health = 100; 

    [Range(0,1)]
    public float iTime = 1;

    private float _xSpeed, _ySpeed;
    Rigidbody2D rb2d;
    
    private GameObject _wand;
    
    void Start()
    {
        _wand = GameObject.Find("Wand");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _xSpeed = Input.GetAxis("Horizontal") * movSpeed;
        _ySpeed = Input.GetAxis("Vertical") * movSpeed;
        rb2d.linearVelocity = new Vector2(_xSpeed, _ySpeed);

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float rotZ = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        _wand.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    
    IEnumerator IFrame()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(iTime);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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

        Gizmos.color = Color.cyan;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawWireSphere(mousePos, 1);
    }
}
