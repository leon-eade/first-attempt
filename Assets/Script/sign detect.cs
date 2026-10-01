using UnityEngine;

public class signdetect : MonoBehaviour
{
    public bool text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text = false;
        }
    }
}
