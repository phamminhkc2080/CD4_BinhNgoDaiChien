using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D enemyRb;
    Animator enemyAnim;

    // kb cac bien

    public GameObject enemyGraphic;
    bool facingRight = true;

    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            Flip();
        }
    }
    void Flip()
    {
        if (!canFlip)
            return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1f;
        enemyGraphic.transform.localScale = theScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                Flip();
            }else if(!facingRight && collision.transform.position.x > transform.position.x)
            {
                Flip();
            }
            canFlip = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!facingRight)
            
                enemyRb.AddForce(new Vector2(-1, 0) * enemySpeed);
            else
            
                enemyRb.AddForce(new Vector2(1, 0) * enemySpeed);
            enemyAnim.SetBool("Run", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            enemyRb.velocity = new Vector2(0, 0);
            enemyAnim.SetBool("Run", false);
        }
    }
}
