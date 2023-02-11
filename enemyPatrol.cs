using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{   
    [SerializeField] float speed = 1f;
    Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight()){
            myRigid.velocity = new Vector2(speed, 0f);
        }
        else{
            myRigid.velocity = new Vector2(-speed, 0f);
        }
    }

    private bool isFacingRight(){
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision){
        transform.localScale = new Vector2(-(Mathf.Sign(myRigid.velocity.x)), transform.localScale.y);
    }
}
