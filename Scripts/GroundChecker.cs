using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    GameObject Player;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject;
        //grounded = Player.GetComponent<Movement>().isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cool");
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
            
            
        }
        if (collision.collider.tag == "Player")
        {
            grounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("cool");
        if (collision.collider.tag == "Ground")
        {
            grounded = false;
            
        }
        
    }
}
