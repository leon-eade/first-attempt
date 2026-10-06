using UnityEditorInternal;
using UnityEngine;

public class destroysansreturnattack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    helperscript helper;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Kaboom", 5);
        if (rb.linearVelocityX > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Kaboom", 0.5f);
        }
    }
    void Kaboom()
    {
        Destroy(gameObject);
    }
}
