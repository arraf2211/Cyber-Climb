using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{   
    [SerializeField] float speed = 1f;
    Rigidbody2D myRigid;

    [SerializeField] Transform castPos;
    [SerializeField] float baseCaseDist;

    Vector3 baseScale;
    public Animator animatorPlayer1;

    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer1 = gameObject.GetComponent<Animator>();
        myRigid = GetComponent<Rigidbody2D>();
        baseScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // if(!transform.hasChanged){
        //     myRigid.velocity = new Vector2(-speed, 0f);
        //     /* if(isFacingRight()){
        //     myRigid.velocity = new Vector2(speed, 0f);
        //     transform.hasChanged = false;
        //     }
        //     else{
        //     myRigid.velocity = new Vector2(-speed, 0f);
        //     transform.hasChanged = false;
        //     } */
        //     //transform.hasChanged = false;
        // }
        // else{

        if(isHittingWall()){
            print("hit");
            transform.localScale = new Vector2(-(Mathf.Sign(myRigid.velocity.x)/2), transform.localScale.y);
            if(isFacingRight()){
                myRigid.velocity = new Vector2(speed, 0f);
                animatorPlayer1.SetBool("Running", true);
            }
            else{
                myRigid.velocity = new Vector2(-speed, 0f);
                animatorPlayer1.SetBool("Running", true);
            }
        }
        else{
            if(isFacingRight()){
                myRigid.velocity = new Vector2(speed, 0f);
                animatorPlayer1.SetBool("Running", true);
            }
            else{
                myRigid.velocity = new Vector2(-speed, 0f);
                animatorPlayer1.SetBool("Running", true);
            }
        }
            

            
        //}
        
        
    }

    private bool isFacingRight(){
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision){
        transform.localScale = new Vector2(-(Mathf.Sign(myRigid.velocity.x)/2), transform.localScale.y);
    }

    bool isHittingWall(){
        bool hit = false;

        float castDist = baseCaseDist;
        if( !isFacingRight()){
            castDist =  -baseCaseDist;
        }
        else{
            castDist = baseCaseDist;
        }

        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        if(Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Platform"))){
            hit = true;
        }
        else{
            hit = false;
        }


        return hit;
    }

    

    
}
