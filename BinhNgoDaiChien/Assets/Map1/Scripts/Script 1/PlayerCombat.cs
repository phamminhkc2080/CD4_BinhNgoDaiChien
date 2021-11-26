using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage;

    public GameObject voiChien;
    public Transform outPutVoi;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.O) && DialogueManager.combat)
        {
            CallVoi();
        }
    }

    private void CallVoi()
    {
        if (UIManager3.SLvoi > 0)
        {
            if(this.transform.localScale.x>0)
                Instantiate(voiChien, outPutVoi.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            else Instantiate(voiChien, outPutVoi.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            UIManager3.SLvoi--;

        }
    }

    void Attack()
    {
        //play an actack animation
        animator.SetTrigger("Attack");
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        // Damage them

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("Hit enemy!" + enemy.name);

            if (enemy.name == "Boss")
                enemy.GetComponent<BossHealth>().TakeDamage(attackDamage);
            else enemy.GetComponent<EnemyHealth>().addDamage(attackDamage);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        
            return;
        // v? hình tròn ?? xác ??nh
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
