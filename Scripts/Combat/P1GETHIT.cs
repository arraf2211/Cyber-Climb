using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1GETHIT : MonoBehaviour
{
    public float P1health; //max HEALTH OF PLAYER1
    
    public HealthBar HealthBar1; //for health bar
    public SpecialBar SpecialBar1;

    public Animator animatorPlayer;

    public GameObject HitBox;         //HITBOXES USED TO REGISTER THE ATTACK
    public GameObject HeavyHitBox;
    public GameObject ULTHitBox;
    public GameObject SpecialHitbox;
    public GameObject ULTvideo;
    public int TimeToStop;
    public GameObject HUD;

    public float LightAttack; //USED TO SHOW HOW MUCH DAMAGE TO OUPTUT
    public float HeavyAttack;
    public float SpecialAttack;

    public GameObject WinnerUI; //to show if p2 has won
    

    //cool down for special if changed change at P1special
   public float CooldownTime = 10; //cooldown time
   private float nextCoolDownTime = 10; //cooldown when they can use the ability 

    // Start is called before the first frame update
    void Start()
    {

        HealthBar1.SetMaxHealth(P1health);
    }

    // Update is called once per frame
    void Update()
    {
        if (P1health <= 0)
        {
            WinnerUI.SetActive(true); //will show that p2 has won
            //FindObjectOfType<GameManager>().Finished();
            
        }
    }

    void OnTriggerEnter2D(Collider2D target) //if the collider clllides with the hitbox then
    {
        if (target.tag == HitBox.tag) //if the hotbox tag is the same then make the enemy lose health //LIGHT ATTACK HITBOX
        {
            
            P1health -= LightAttack;
            //animatorPlayer.SetBool("Stunned", true);
            StartCoroutine(WaitSeconds());
            HealthBar1.SetHealth(P1health);//new helath is used to set the health bar 
            
            
        }
        if (target.tag == HeavyHitBox.tag)//if collides with heavy hitbox then make em lose health
        {
            
            P1health -= HeavyAttack;//lose how much which is stated in the heavy section
            animatorPlayer.SetBool("Stunned", true);
            StartCoroutine(WaitSeconds());
            HealthBar1.SetHealth(P1health);
        }

        if (target.tag == SpecialHitbox.tag)
        {
            P1health -= SpecialAttack;
            nextCoolDownTime = Time.time + CooldownTime;//this basically resets the timer for cooldown
            animatorPlayer.SetBool("Stunned", true);
            StartCoroutine(WaitSeconds());
            HealthBar1.SetHealth(P1health);
           
        }

        if (target.tag == ULTHitBox.tag)//if collides with ULT1 hitbox then make em lose health
        {
            //animatorPlayer.SetBool("Stunned", true); uncomment when uve worked out how to make the player appear on screen
            ULTvideo.SetActive(true); //plays the video
            HUD.SetActive(false); //causes hud to hide 
            StartCoroutine(WaitForSeconds());//calls the wait for seconds rountine, where after how long the video will stop playing, and the canvas will return


        }

        

    }
    private IEnumerator WaitForSeconds() //for being attack by ult attacks
    {
        yield return new WaitForSeconds(TimeToStop);
        ULTvideo.SetActive(false);
        HUD.SetActive(true);
        P1health -= 75;//lowers health
        HealthBar1.SetHealth(P1health);
    }

    private IEnumerator WaitSeconds() //for being attack by attacks
    {
        yield return new WaitForSeconds(1);
        animatorPlayer.SetBool("Stunned", false);
        
    }
}
