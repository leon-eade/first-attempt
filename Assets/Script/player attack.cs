using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public GameObject weapon;
    float velx;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("kaboom", 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
        else if (collision.gameObject.tag == "sans")
        {
            Invoke("SpawnAttack", 0.5f);
            velx= rb.linearVelocity.x;
            rb.linearVelocity = new Vector2(0, 0);
            Invoke("kaboom", 0.5f);
        }
        else if (collision.gameObject.tag == "text")
        {
            
        }
        else if (collision.gameObject.tag == "player attack")
        {

        }
        else if (collision.gameObject.tag == "coin")
        {

        }
        else if (collision.gameObject.tag == "checkpoint")
        {

        }
        else
        {
            kaboom();
        }
    }
    private void SpawnAttack()
    {
        GameObject clone;
        clone = Instantiate(weapon, transform.position, Quaternion.Euler(0, transform.rotation.x - 180, 0));
        Rigidbody2D rb2 = clone.GetComponent<Rigidbody2D>();
        rb2.linearVelocity = new Vector2(velx*-1, 0);
        rb2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    void kaboom()
    {
        Destroy(gameObject);
    }
}
