using Unity.Mathematics;
using UnityEngine;

public class textmove : MonoBehaviour
{
    public signdetect move;
    float x;
    float y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (move.text == true)
        {
            transform.position = new Vector3(x, y, 0);
        }
        else
        {
            transform.position = new Vector3(-399, -1758, 0);
        }
    }
}
