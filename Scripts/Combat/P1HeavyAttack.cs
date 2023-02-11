using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1HeavyAttack : MonoBehaviour
{
    public int noOfHeavyInputs = 0; //HEAVY ATTACK
    float lastClickedTime = 0;
    public float maxHeavyComboDelay;
    public Animator animatorPlayer1;


    private P1HeavyDamage HeavydamageScript;
    public GameObject HeavyHitBox;

    // Start is called before the first frame update
    void Start()
    {
        HeavydamageScript = HeavyHitBox.GetComponent<P1HeavyDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastClickedTime > maxHeavyComboDelay)//if the time of the system minus the last time clicked is less than maxcombodelay then
        {
            noOfHeavyInputs = 0;  //make the no of input(how many times attack button is pressed) = 0
        }
        //Heavy ATTACK
        if (Input.GetKeyDown("k")) //if k is pressed then 
        {
            lastClickedTime = Time.time;//click time = time of program
            noOfHeavyInputs++; //increase the no of inputs, this allows for the other attacks
            if (noOfHeavyInputs == 1) //if only the k is pressed once then 
            {
                animatorPlayer1.SetBool("HeavyAttack1", true); //animator is plays the Heavyattack by setting the bool condition to true

            }

            noOfHeavyInputs = Mathf.Clamp(noOfHeavyInputs, 0, 3);//makes max inputs 3
        }
    }


        public void returnHeavy1()  //this is added to the first attack animation as an event makes sure that if the js pressed more than 2 ,make the animator play the second attck 
        {
            //HEAVY ATTACK 2
        if (noOfHeavyInputs >= 2) //if input greater or equal to 2 then
        {
            animatorPlayer1.SetBool("HeavyAttack2", true);//this is true making the second attack play
            
        }
        else //if less than 2
        {
            animatorPlayer1.SetBool("HeavyAttack1", false);//lightattack1 is false as it has already been played
            noOfHeavyInputs = 0;//reset counter
        }
        }

        public void returnHeavy2()//does same as above but placed at end of animation2 as an event 
        {
            
            //HEAVY ATTACK 3
            if (noOfHeavyInputs >= 3)//if the inputs = 3 then play the 3 attack
            {
                animatorPlayer1.SetBool("HeavyAttack3", true);
                animatorPlayer1.SetBool("IsRunning", false);
            }
            else //if less than 3 then set the previous attacks as false as you dont want them to play again
            {
                animatorPlayer1.SetBool("HeavyAttack2", false);
                animatorPlayer1.SetBool("HeavyAttack1", false);
                noOfHeavyInputs = 0;
            }

        }
        public void returnHeavy3() //this is for the idle animation, at the start of it and the last attack at its end
        {
            
            //HEAVY ATTACK
            animatorPlayer1.SetBool("HeavyAttack1", false);//makes sure that this is false so that the combo doesnt start again straight away and the counter resets
            animatorPlayer1.SetBool("HeavyAttack2", false);
            animatorPlayer1.SetBool("HeavyAttack3", false);
            noOfHeavyInputs = 0;
        }
        public void HeavyChangeDam(int newDmg)//this is for the combos, so with each attack it increases in damage, this is added as an event to the attacks, at the start of them
        {
            HeavydamageScript.HeavyDamageGiven = newDmg;
        }
 
    }
