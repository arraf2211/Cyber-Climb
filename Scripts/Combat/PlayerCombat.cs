using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j"))
        {
            Attack(); 
        }
    }
        void Attack() 
        {
            //play animation (do later when animations recieved)

        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //damage them 
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        }
        void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);  
        }
        
    }

