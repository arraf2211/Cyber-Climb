using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
        public float moveSpeed; //character speed
    public bool isGrounded = false;//to check if the player is on the ground
    public float moveAnimation; //to find speed of the player for the running animation

    public KeyCode Player1Left;//player1 left key so A
    public KeyCode Player1right;//RIGHT KEY SO D
    public KeyCode PlayerJump;//JUMP KEY SO W
    public KeyCode LightAttack;//J KEY                 THESE KEYS CAN BE CHANGED ON THE CHARACTER
    public KeyCode Player1Block;//K KEY
    public KeyCode Player1Heavy;//L KEY
    public KeyCode Player1Special;//H KEY
    public KeyCode Player1ULT;//i KEY
    
    public Animator animatorPlayer1;//then drag animator into this part on unity
    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer1 = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        Vector3 PlayerScale = transform.localScale;

        if (Input.GetKey(Player1Left))
        {
            transform.position = new Vector3(transform.position .x - 1 * Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);//moves it to the left
            PlayerScale.x = -(System.Math.Abs(PlayerScale.x)); //flips sprite to left
            animatorPlayer1.SetBool("IsRunning", true); //play running animation
        }
        else if (Input.GetKey(Player1right))
        {
            transform.position = new Vector3(transform.position.x + 1 * Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);//moves to right
            PlayerScale.x = System.Math.Abs(PlayerScale.x);//flips it right
            animatorPlayer1.SetBool("IsRunning", true);//play runnning animation
        }
        else //no buttons pressed so stand still, so running is set to false
        {
            animatorPlayer1.SetBool("IsRunning", false);
        }

        if (Input.GetKey(Player1Block)) //block attack, make sure to add that when blocking no damage is dealt
        {
            animatorPlayer1.SetBool("IsBlocking", true);
        }
        else
        {
            animatorPlayer1.SetBool("IsBlocking", false);
        }

        

        


        
       // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;
       // moveAnimation = Input.GetAxis("Horizontal");
        //adds spped to player for animation
        //this to flip the player wehn they move left or right 
        transform.localScale = PlayerScale;

        
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(PlayerJump) && isGrounded == true)//if w is pressed and is grounded allow it to jump
        {
            
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);//adds a force in y axis so jumping
            animatorPlayer1.SetBool("Jumping", true);//sets jumping in animator as true
            
        }
        else //if no jumping then
        {
            Landed();//call up landed function
        }
        if (isGrounded == false)//if grounded is false so in the sky
        {
            animatorPlayer1.SetBool("Jumping", true);//this is true so that  it plays the jumping animation to look like falling
        }
    }

    public void Landed()//landed function
    {
        animatorPlayer1.SetBool("Jumping", false);//tells the animator that it has landed so stops playing the jumping animation
    }

    



}
