using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject HitBox;
    public GameObject enemy;
    public Animator animatorPlayer;
    public Rigidbody2D rb;
    public Collider2D coll;
    public int MaxHealth = 100;
    public int currentHealth;
    public int damageReceive;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        coll = GetComponent<Collider2D>();
    }

    void Update(){
        if (currentHealth <= 0)
        {
            animatorPlayer.SetBool("Dead",true);
            // coll.enabled = false;
            //     rb.mass = 5f;
            //     rb.gravityScale = 3f;
                StartCoroutine("KillSwicth");
            //StartCoroutine(WaitSeconds(2));
            //Destroy(enemy); //unless better way of destroying enemy
        }
    }

    public void TakeDamage()
    {
        currentHealth -= damageReceive; //play hurt animation and sound
        //damageScript = HitBox.GetComponent<P1GivenDam>(); //gets variable from the P1 given damage 
        
    }

    void OnTriggerEnter2D(Collider2D target) //if the collider clllides with the hitbox then
    {
        if (target.tag == HitBox.tag) //if the hotbox tag is the same then make the enemy lose health
        {
            currentHealth -= damageReceive; 
            animatorPlayer.SetBool("Stunned", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;// gotta do this so that it stops moving, and also coz if I freeze a single axis the Z axis gets unfrozen???
            // if(currentHealth <= 0){
            //     animatorPlayer.SetBool("Dead",true);
                
            // }
           // GameScript.GetComponent<Player2Movement>().enabled = false; //fix
           StartCoroutine(WaitSeconds(1));
        }
    }
    private IEnumerator WaitSeconds(int time) //for being attack by attacks
    {
        yield return new WaitForSeconds(time);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//allows it to keep rotation frozen
        animatorPlayer.SetBool("Stunned", false);
       // GameScript.GetComponent<Player2Movement>().enabled = true;
    }

    IEnumerator KillSwicth(){
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    
    
}
