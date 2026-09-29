using UnityEngine;

public class missilebottom : MonoBehaviour
{
    public shhotyenemy shoot;
    int directionMove2;
    Rigidbody2D rb;
    public Transform shooter;
    public LayerMask player;
    bool shoots;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shoots = shoot.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot.directionface == "left")
        {
            directionMove2 = -6;
            if (RayCollisionCheckLeft(0, 0))
            {
                print("bot hit");
            }
        }
        else
        {
            directionMove2 = 6;
            if(RayCollisionCheckRight(0, 0))
            {
                print("bot hit");
            }
        }
        if (!shoot.shooting)
        {
            transform.position = new Vector3(shooter.position.x-0.5f, shooter.position.y - 0.3f,0);
        }
        else
        {
            rb.linearVelocity = new Vector2(directionMove2, 0);
        }
    }
    public bool RayCollisionCheckRight(float xoffs, float yoffs)
    {
        float rayLength = 0.5f;
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
        float rayLength = 0.5f;
        bool hitSomethingRight = false;


        Vector3 offset = new Vector3(xoffs, yoffs, 0);


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.left, rayLength, player);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {

            hitColor = Color.green;
            hitSomethingRight = true;
        }

        Debug.DrawRay(transform.position + offset, Vector2.left * rayLength, hitColor);
        return hitSomethingRight;
    }
}