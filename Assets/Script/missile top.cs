using UnityEngine;

public class missiletop : MonoBehaviour
{
    public shhotyenemy shoot;
    int directionMove2;
    Rigidbody2D rb;
    public Transform shooter;
    public LayerMask player;
    bool shoots;
    public bool hitmt;
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
        }
        else
        {
            directionMove2 = 6;
        }
        if (!shoot.shooting)
        {
            transform.position = new Vector3(shooter.position.x+0.5f, shooter.position.y - 0.1f, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(directionMove2, 0);
        }
    }
  
}