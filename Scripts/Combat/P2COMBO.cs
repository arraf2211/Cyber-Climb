using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2COMBO : MonoBehaviour
{
    public Animator animatorPlayer;
    public int noOfLightInputs = 0;  // LIGHT ATTACK COMBOS

    float lastClickedTime = 0;
    public float maxLightComboDelay;
    public int LightAttack;
    private P1GivenDam damageScript; //DAMAGE SCRIPT
    public GameObject HitBox;
    public KeyCode PlayerLightAttack; //allows em to chose keybindings

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastClickedTime > maxLightComboDelay)//if the time of the system minus the last time clicked is less than maxcombodelay then
        {
            noOfLightInputs = 0; //make the no of input(how many times attack button is pressed) = 0
        }



        if (Input.GetKeyDown(PlayerLightAttack)) //if z is pressed then 
        {
            lastClickedTime = Time.time;//click time = time of program
            noOfLightInputs++; //increase the no of inputs, this allows for the other attacks
            if (noOfLightInputs == 1) //if only the j is pressed once then 
            {
                animatorPlayer.SetBool("LightAttack1", true); //animator is plays the lightattack by setting the bool condition to true

            }

            noOfLightInputs = Mathf.Clamp(noOfLightInputs, 0, 3);//makes max inputs 3
        }
    }

    public void return21() //this is added to the first attack animation as an event makes sure that if the js pressed more than 2 ,make the animator play the second attck 
    {
        if (noOfLightInputs >= 2) //if input greater or equal to 2 then
        {
            animatorPlayer.SetBool("LightAttack2", true);//this is true making the second attack play
            animatorPlayer.SetBool("Running", false);
        }
        else //if less than 2
        {
            animatorPlayer.SetBool("LightAttack1", false);//lightattack1 is false as it has already been played
            noOfLightInputs = 0;//reset counter
        }

    }

    public void return22()//does same as above but placed at end of animation2 as an event 
    {
        if (noOfLightInputs >= 3)//if the inputs = 3 then play the 3 attack
        {
            animatorPlayer.SetBool("LightAttack3", true);
            animatorPlayer.SetBool("Running", false);
        }
        else //if less than 3 then set the previous attacks as false as you dont want them to play again
        {
            animatorPlayer.SetBool("LightAttack2", false);
            animatorPlayer.SetBool("LightAttack1", false);
            noOfLightInputs = 0;
        }


    }

    public void return23() //this is for the idle animation, at the start of it and the last attack at its end
    {
        animatorPlayer.SetBool("LightAttack1", false);//makes sure that this is false so that the combo doesnt start again straight away and the counter resets
        animatorPlayer.SetBool("LightAttack2", false);
        animatorPlayer.SetBool("LightAttack3", false);
        noOfLightInputs = 0;

    }

    public void ChangeDam(int newDmg)//this is for the combos, so with each attack it increases in damage, this is added as an event to the attacks, at the start of them
    {
       // damageScript.LightDamageGiven = newDmg;
    }
}
