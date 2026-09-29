using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class shhotyenemy : MonoBehaviour
{
    
    Rigidbody2D rb;
    public LayerMask groundLayer;
    public LayerMask player;
    int directionFaceNum;
    bool canShoot = false;
    int countBeforShoot;

    public string directionface;
    public bool shooting = false;
    int directionMove;

    int reload = 1400;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (directionface == "right")
        {
            if (RayCollisionCheckRight(0, -0.1f) )
            {
                canShoot = true;
            }
            else
            {
                canShoot = false;
            }
        }
        else if (directionface == "left")
        {
            if (RayCollisionCheckLeft(0, -0.1f))
            { 
                canShoot = true;
            }
            else
            {
                canShoot = false;
            }
        }
        if (!canShoot)
        {
            reload += 1;
            movement();
            countBeforShoot = 0;
            if (reload > 1400)
            {
                shooting = false;
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
            reload += 1;
            if (reload > 1400)
            {
                shooting = false;
                countBeforShoot += 1;
                if (countBeforShoot > 250)
                {
                    reload = 0;
                    countBeforShoot = 0;
                    shooting = true;
                }
            }
        }

        
    }
    void movement()
    {
        if (!RayCollisionCheckDown(-0.75f, 0))
        {
            directionFaceNum = 180;
            directionface = "right";
            transform.localRotation = Quaternion.Euler(0, directionFaceNum, 0);
            directionMove = 2;
        }
        if (!RayCollisionCheckDown(0.75f, 0))
        {
            directionMove = -2;
            directionFaceNum = 0;
            directionface = "left";
            transform.localRotation = Quaternion.Euler(0, directionFaceNum, 0);
        }
        rb.linearVelocity = new Vector2(directionMove, rb.linearVelocity.y);
    }
    public bool RayCollisionCheckDown(float xoffs, float yoffs)
    {
        float rayLength = 1f;
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
    public bool RayCollisionCheckRight(float xoffs, float yoffs)
    {
        float rayLength = 15f;
        bool hitSomethingRight = false;


        Vector3 offset = new Vector3(xoffs, yoffs, 0);


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.right, rayLength, player);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
           
            hitColor = Color.green;
            hitSomethingRight = true;
        }

        Debug.DrawRay(transform.position + offset, Vector2.right * rayLength, hitColor);
        return hitSomethingRight;
    }
    public bool RayCollisionCheckLeft(float xoffs, float yoffs)
    {
        float rayLength = 15f;
        bool hitSomethingLeft = false;


        Vector3 offset = new Vector3(xoffs, yoffs, 0);


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.left, rayLength, player);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
         
            hitColor = Color.green;
            hitSomethingLeft = true;
        }

        Debug.DrawRay(transform.position + offset, Vector2.left * rayLength, hitColor);
        return hitSomethingLeft;
    }
}
