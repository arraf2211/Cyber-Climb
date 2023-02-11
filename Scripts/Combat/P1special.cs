using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1special : MonoBehaviour
{

    //special
    public float CooldownTime = 10; //cooldown time
    public float nextCoolDownTime = 10; //cooldown when they can use the ability 
    public SpecialBar SpecialBar1;
    
    //ULTIMATE INDICATOR
    
    public float ULTCoolDownTime; //cooldown when they can use the ability 
    public float nextULTCoolDownTime; 
    public GameObject ULTBar; //is a game object that the ult indicator will be placed into
    private bool ULTnumber = false;//will be false at first but when the ult is ready it will be true
    public GameObject ULTvideo;
    public int TimeToStop;
    public GameObject HUD;

    //Keycodes and animators
    public Animator animatorPlayer1;
    public KeyCode PlayerSpecial;
    public KeyCode PlayerULT;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //at start the special and ult will have to start at 0 or false
        nextCoolDownTime = Time.timeSinceLevelLoad + nextCoolDownTime; //so at start of first frame the next cooldown
        nextULTCoolDownTime = Time.timeSinceLevelLoad + nextULTCoolDownTime;
        SpecialBar1.SetSpecial(0);
        ULTBar.SetActive(false);
        ULTvideo.SetActive(false);
        
        
    }

    // Update is called once per frame
    private void Update()
    {

        //SPECIAL BAR
        if (Time.timeSinceLevelLoad > nextCoolDownTime)//if the game has a greater time than the next cooldownTime
        {
            SpecialBar1.SetSpecial(CooldownTime);
            
            
            if (Input.GetKeyDown(PlayerSpecial))//if the input if h or v
            {
                animatorPlayer1.SetBool("SpecialAttack", true);//play the special ability 
                nextCoolDownTime = Time.timeSinceLevelLoad + CooldownTime;//this basically resets the timer for next time to do special ability 
                SpecialBar1.SetSpecial(0);
                
            }
            
        }

        //is what builds up the bar and also resets it when new round due to its time.timesincelevel load
        SpecialBar1.SetSpecial(-nextCoolDownTime + Time.timeSinceLevelLoad + CooldownTime);//refresh and allows it to build up, 



        //ULT
        if (Time.timeSinceLevelLoad > nextULTCoolDownTime) //if the game time is greater than cooldown time then true, so allowing code underneath to run   
        {
            //ULTnumber = true; //set to true as ult is ready
            //if (ULTnumber == true) //if true then allow ult to occur
            //{
                ULTBar.SetActive(true);

                if (Input.GetKeyDown(PlayerULT))
                {
                    animatorPlayer1.SetBool("UltimateAttack1", true);
                    nextULTCoolDownTime = Time.timeSinceLevelLoad + ULTCoolDownTime;
                    ULTBar.SetActive(false);
                    
                }
           // }
            
        }
        
        
    }

    

    public void SpecialReturn()
    {
        if (Time.timeSinceLevelLoad < nextCoolDownTime)
        {
            animatorPlayer1.SetBool("SpecialAttack", false);
        }
    }

    public void ULTReturn()
    {
        if (Time.timeSinceLevelLoad < nextULTCoolDownTime)
        {
            animatorPlayer1.SetBool("UltimateAttack1", false);
        }
    }
    
        
            
        
    
    
}
