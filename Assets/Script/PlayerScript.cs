using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerScript2 : MonoBehaviour
{
    public float positionx;
    InputAction moveAction;
    InputAction attackAction;
    helperscript helper;
    float y = -0.15f;
    bool left;
    float x = -17.55f;
    InputAction jumpAction;
    InputAction attack2Action;
    public healthbar h;
    public bool checkHit;
    public bool heal;
    public GameObject weapon;
    public bool hite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    bool isGrounded;
    public int jumpNum;
    int count = 750;
    Animator anim;
    public LayerMask groundLayer;
    void Start()
    {
        helper = gameObject.AddComponent<helperscript>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        attack2Action = InputSystem.actions.FindAction("attack2");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Isgrounded();
        Jump();
        IsWalking();
        Direction();
        Heal1();
        Attack();
        Attack2();
    }
    void Move()
    {
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveVel.x*5, rb.linearVelocity.y);
    }
    void Isgrounded()
    {
        if (RayCollisionCheckDown(0, 0) || RayCollisionCheckDown(-0.35f, 0) || RayCollisionCheckDown(0.35f, 0))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void Attack()
    {
        count += 1;
        if (attackAction.WasPressedThisFrame())
        {
            if (count >= 750)
            {
                count= 0;
                SpawnAttack();
            }
        }
    }
    void Attack2()
    {
        count += 1;
        if (attack2Action.WasPressedThisFrame())
        {
            if (count >= 750)
            {
                count= 0;
                SpawnAttack2();
            }
        }
    }
    void SpawnAttack()
    {
        GameObject clone;
        clone = Instantiate(weapon, transform.position, transform.rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        if (left == true)
        {
            rb.linearVelocity = new Vector2(5, 0);
            rb.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
        }
        else
        {
            rb.linearVelocity = new Vector2(-5, 0);
            rb.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
        }
    }
    void SpawnAttack2()
    {
        GameObject clone;
        clone = Instantiate(weapon, transform.position, transform.rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        if (left == true)
        {
            rb.linearVelocity = new Vector2(5, 0);
            rb.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y-0.5f, transform.position.z);
            clone = Instantiate(weapon, transform.position, transform.rotation);
            rb = clone.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(5, 0);
            rb.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y + 0.4f, transform.position.z);
        }
        else
        {
            rb.linearVelocity = new Vector2(-5, 0);
            rb.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y - 0.5f, transform.position.z);
            clone = Instantiate(weapon, transform.position, transform.rotation);
            rb = clone.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(-5, 0);
            rb.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y + 0.4f, transform.position.z);
        }
    }

    void Heal1()
    {
        if (h.health <= 0)
        {
            heal = true;
            transform.position = new Vector3(x,y,0);
        }
        else
        {
        heal= false;
        }
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
    void Direction()
    {
        if (rb.linearVelocityX > 0)
        {
            left = true;
            helper.FlipSprite(false);
        }
        else if (rb.linearVelocityX < 0)
        {
            left = false;
            helper.FlipSprite(true);

        }
    }
    void IsWalking()
    {
        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if (isGrounded)
        {
            anim.SetBool("jumping", false);
            jumpNum = 1;
        }
        if (!isGrounded)
        {
            anim.SetBool("jumping", true);
        }
        if (jumpAction.triggered)
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7.5f);
            }
            else if (jumpNum > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x,7.5f);
                jumpNum -= 1;
            }
        }
    }
    void removeJump()
    {
        jumpNum = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy"|| collision.gameObject.tag == "hazards")
        {
            hite = true;
            checkHit = true;
        }
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        checkHit = false;
        hite = false;
        if (collision.gameObject.tag == "player attack")
        {
            Invoke("removeJump", 0.5f);
            print("no longre touching attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hazards")
        {
            hite = true;
            checkHit = true;
        }
        if (collision.gameObject.tag == "checkpoint")
        {
            x=transform.position.x;
            y=transform.position.y;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkHit = false;
        hite = false;

    }
}

