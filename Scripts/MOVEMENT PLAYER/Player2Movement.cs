using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{

    public float moveSpeed = 15f; //character speed
    public bool isGrounded = false;//to check if the player is on the ground
    public float moveAnimation; //to find speed of the player for the running animation

    public KeyCode Player2Left;//player2 left key so left key
    public KeyCode Player2right;//RIGHT KEY SO right key
    public KeyCode Player2Jump;//JUMP KEY SO up key
    public KeyCode Player2LightAttack;//so z key                 THESE KEYS CAN BE CHANGED ON THE CHARACTER
    public KeyCode Player2Block;//so x key
    public KeyCode Player2Heavy;//c key
    public KeyCode Player2Special;// v key


    //add animator for this player
    public Animator animatorPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 PlayerScale = transform.localScale;
        if (Input.GetKey(Player2Left))
        {
            transform.position = new Vector3(transform.position.x - 1 * Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);//moves it to the left
            PlayerScale.x = 1; //flips sprite to right
            animatorPlayer2.SetBool("Running", true); //play running animation
        }
        else if (Input.GetKey(Player2right))
        {
            transform.position = new Vector3(transform.position.x + 1 * Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);//moves to right
            PlayerScale.x = -1;//flips it left as they start opposite to player 1
            animatorPlayer2.SetBool("Running", true);
        }
        else //no buttons pressed so stand still, so running is set to false
        {
            animatorPlayer2.SetBool("Running", false);
        }
        transform.localScale = PlayerScale;

        if (Input.GetKey(Player2Block)) //block attack, make sure to add that when blocking no damage is dealt
        {
            animatorPlayer2.SetBool("IsBlocking", true);
        }
        else
        {
            animatorPlayer2.SetBool("IsBlocking", false);
        }

        
        

    }

    void Jump()
    {
        if (Input.GetKeyDown(Player2Jump) && isGrounded == true)//if up is pressed and is grounded allow it to jump
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);//adds a force in y axis so jumping
            animatorPlayer2.SetBool("jumping", false);

        }
        else //if no jumping then
        {
            Landed();//call up landed function
        }
        if (isGrounded == false)//if grounded is false so in the sky
        {
            animatorPlayer2.SetBool("jumping", true);
        }
    }

    public void Landed()//landed function
    {
        animatorPlayer2.SetBool("jumping", false);
    }
}
