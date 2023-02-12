using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDetections : MonoBehaviour
{
    public Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(this.gameObject.tag == collider.tag){
            transform.localScale = new Vector2(-(Mathf.Sign(myRigid.velocity.x)/2), transform.localScale.y);
        }
        
    }
}
