using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    float dameRate = 1f;
    public float pushBackForce;

    float nextDamage;


    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            //Debug.Log("Mat Mau");
            Player_Health thePlayerHealth = collision.gameObject.GetComponent<Player_Health>();
            thePlayerHealth.addDamage(damage);
            nextDamage = dameRate + Time.time;

            pushBack(collision.transform);
        }
    }
   
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRb = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRb.velocity = Vector2.zero;
        pushRb.AddForce(pushDirection, ForceMode2D.Impulse);

    }
}
