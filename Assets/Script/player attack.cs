using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    

    void kaboom()
    {
        Destroy(gameObject);
    }
}
