using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator playerAnim;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemyLayers;
    private int damage = 25;

    public float attackRate = 1.5f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
       if(Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.F))
            {

                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }
        }
            
           
        
       
    }
    void Attack()
    {
        playerAnim.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);
   
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("vurudk");
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPos == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
