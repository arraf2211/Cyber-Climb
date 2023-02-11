using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerPlayer2 : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<Player2Movement>().isGrounded = true;
            

        }
        if (collision.collider.tag == "Player")
        {
            Player.GetComponent<Player2Movement>().isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<Player2Movement>().isGrounded = false;
            
            
        }
    }
}
