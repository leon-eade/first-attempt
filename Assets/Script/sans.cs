using UnityEngine;

public class sans : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player attack")
        {
            anim.SetBool("attacked",true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player attack")
        {
            Invoke("StopAnim", 1f);
        }
    }
    void StopAnim()
    {
        anim.SetBool("attacked", false);
    }
}
