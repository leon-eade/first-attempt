using UnityEngine;

public class healthbar : MonoBehaviour
{
    Animator anim;
    public PlayerScript2 h3;
    bool hit = false;
    public int health = 5;
    bool immune = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (h3.heal)
        {
            health = 5;
        }
        displayhealth();
        if (immune == false)
        {
            if (h3.checkHit)
            {
                damage();
            }
        }
        if (hit == true)
        {
            health -= 1;
            displayhealth();
            hit = false;
            immune = true;
            Invoke("damage",4);
        }
    }
    void damage()
    {
        if (h3.hite)
        {
            hit = true;
        }
        else
        {
            hit=false;
        }
        immune = false;
    }
    void displayhealth()
    {
        if (health == 5)
        {
            anim.SetBool("damage1", false);
            anim.SetBool("damage2", false);
            anim.SetBool("damage3", false);
            anim.SetBool("damage4", false);
            anim.SetBool("damage5", false);
        }
        else if (health == 4)
        {
            anim.SetBool("damage1", true);
            anim.SetBool("damage2", false);
        }
        else if (health == 3)
        {
            anim.SetBool("damage2", true);
            anim.SetBool("damage3", false);
        }
        else if (health == 2)
        {
            anim.SetBool("damage3", true);
            anim.SetBool("damage4", false);
        }
        else if (health == 1)
        {
            anim.SetBool("damage4", true);
            anim.SetBool("damage5", false);
        }
        else
        {
            anim.SetBool("damage5", true);
        }
    }
    //anim.SetBool("jumping", true);
}
