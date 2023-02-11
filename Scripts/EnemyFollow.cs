using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speedAi;
    public float DistanceFromPlayer;

    public GameObject enemy;
    public Animator animatorPlayer;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //sets the target of those with tag of player
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > DistanceFromPlayer) //compares distance from player to enemy
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedAi * Time.deltaTime);//if is greater than watever value, then it will movetowards the player
            
        }
        float EnemyPosition = transform.position.x;
        Vector3 EnemyScale = transform.localScale;
        if (EnemyPosition > 0)
        {
            EnemyScale.x = -(System.Math.Abs(EnemyScale.x)); //right
        }
        if (EnemyPosition < 0)
        {
            EnemyScale.x = System.Math.Abs(EnemyScale.x);//left
        }
        transform.localScale = EnemyScale;

        if(EnemyPosition >= 0.2){
            animatorPlayer.SetBool("LightAttack1",true);
        }
    }
}
