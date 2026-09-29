using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class coin : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("collected", true);
            Invoke("Collected", 0.7f);

        }

    }

    void Collected()
    {
        Destroy(gameObject);

    }

}