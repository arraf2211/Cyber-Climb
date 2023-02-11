using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2GETHIT : MonoBehaviour
{
    public float P2health;
    public HealthBar HealthBar2; //for health bar
    public HealthBar HealthBar1;
    public SpecialBar SpecialBar2;

    public Animator animatorPlayer;

    private P1GivenDam damageScript;
    private P1HeavyDamage HeavydamageScript;
    private Player2Movement movement;

    public Rigidbody2D rb;
    public GameObject HitBox;
    public GameObject HeavyHitBox;
    public GameObject ULT1HitBox;
    public GameObject SpecialHitBox;
    public GameObject ULTvideo;
    public int TimeToStop;
    public GameObject HUD;

    private GameObject GameScript;

    public GameObject WinnerUI;//to show if p1 has won

    //cool down for special if changed change at P1special
    public float CooldownTime = 10; //cooldown time
    private float nextCoolDownTime = 10; //cooldown when they can use the ability 

    // Start is called before the first frame update
    void Start()
    {
        damageScript = HitBox.GetComponent<P1GivenDam>(); //gets variable from the P1 given damage 
        HeavydamageScript = HeavyHitBox.GetComponent<P1HeavyDamage>();//gets variable from heavy p1
         
        HealthBar2.SetMaxHealth(P2health);
    }

    void Update()
    {
       // if (Input.GetKeyDown("h"))
       // {
       //     
      //  }
        if (P2health <= 0)
        {
            WinnerUI.SetActive(true);
            //FindObjectOfType<GameManager>().Finished();
            
        }
        

        //cooldown from P1Special if you change cool down here change it there
        
            
    }
    void OnTriggerEnter2D(Collider2D target) //if the collider clllides with the hitbox then
    {
        if (target.tag == HitBox.tag) //if the hotbox tag is the same then make the enemy lose health
        {
            P2health -= damageScript.LightDamageGiven;
            animatorPlayer.SetBool("Stunned", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;// gotta do this so that it stops moving, and also coz if I freeze a single axis the Z axis gets unfrozen???
           // GameScript.GetComponent<Player2Movement>().enabled = false; //fix


            
            StartCoroutine(WaitSeconds());
            HealthBar2.SetHealth(P2health);
        }

        if (target.tag == HeavyHitBox.tag)//if collides with heavy hitbox then make em lose health
        {
            P2health -= HeavydamageScript.HeavyDamageGiven;//lose how much which is stated in the heavy section
            animatorPlayer.SetBool("Stunned", true);
            StartCoroutine(WaitSeconds());
            HealthBar2.SetHealth(P2health);
        }

        if (target.tag == ULT1HitBox.tag)//if collides with ULT1 hitbox then make em lose health
        {
            
            ULTvideo.SetActive(true); //plays the video
            HUD.SetActive(false); //causes hud to hide 
            StartCoroutine(WaitForSeconds());//calls the wait for seconds rountine, where after how long the video will stop playing, and the canvas will return
            
            
        }

        if (target.tag == SpecialHitBox.tag)
        {
            P2health -= P2health / 4;
            nextCoolDownTime = Time.time + CooldownTime;//this basically resets the timer for cooldown
            animatorPlayer.SetBool("Stunned", true);
            StartCoroutine(WaitSeconds());
            HealthBar2.SetHealth(P2health);
        }

        
        
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(TimeToStop);
        ULTvideo.SetActive(false);
        HUD.SetActive(true);
        P2health -= 75;//lowers health
        HealthBar2.SetHealth(P2health);
    }

    private IEnumerator WaitSeconds() //for being attack by attacks
    {
        yield return new WaitForSeconds(1);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//allows it to keep rotation frozen
        animatorPlayer.SetBool("Stunned", false);
       // GameScript.GetComponent<Player2Movement>().enabled = true;
    }
    
}
