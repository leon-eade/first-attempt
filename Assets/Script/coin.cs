using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class coin : MonoBehaviour
{
    Animator anim;
    public LayerMask playerLayer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RayCollisionCheck(0, 0);
    }
    public bool RayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.6f;
        bool hitSomething = false;


        Vector3 offset = new Vector3(xoffs, yoffs, 0);


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, playerLayer);

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
