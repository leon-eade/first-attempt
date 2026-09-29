using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class cactienemy : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask groundLayer;
    public Transform Player;
    int direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        rb.linearVelocity = new Vector2(direction, rb.linearVelocity.y);
    }
    void movement()
    {
        if (!RayCollisionCheckDown(-0.4f, 0) )
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction = 3;
        }
        if (!RayCollisionCheckDown(0.4f, 0))
        {
            direction = -3;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public bool RayCollisionCheckDown(float xoffs, float yoffs)
    {
        float rayLength = 1.5f;
        bool hitSomething = false;


        Vector3 offset = new Vector3(xoffs, yoffs, 0);


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayer);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
         
            hitColor = Color.green;
            hitSomething = true;
        }

        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
    
}
