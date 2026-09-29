using UnityEngine;

public class cameramove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public Transform Player;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(Player.position.x + offset.x, Player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
