using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript2 : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    bool isGrounded;
    public int jumpNum;
    Animator anim;
    public LayerMask groundLayer;
    bool result;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveVel.x *5, rb.linearVelocity.y);
        if (RayCollisionCheckDown(0, 0) || RayCollisionCheckDown(-0.4f, 0) || RayCollisionCheckDown(0.4f, 0))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded= false;
        }
            Jump();
        IsWalking();
        Direction();
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
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rb.linearVelocityX < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            print("you dead");
        }
        else if (collision.gameObject.tag == "hazards")
        {
            transform.position = new Vector3(-17.81f, 0.15f, 0);
        }
    }
}

