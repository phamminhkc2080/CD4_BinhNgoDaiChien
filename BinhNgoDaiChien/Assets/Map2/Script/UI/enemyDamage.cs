using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

    public float damage;
    float dameRate = 0.5f;
    public float pushBackForce;// luc tac dung day len
    float nextDamage;// luot gay sat thuong tiep theo


    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && nextDamage < Time.time)
        {
            //Time.time: current Time

            PlayerHealth thePlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = dameRate + Time.time;

            pushBack(collision.transform);// khi cham vao bui cay se nhay len
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            //Time.time: current Time

            PlayerHealth thePlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = dameRate + Time.time;

            pushBack(collision.transform);// khi cham vao enemy se nhay len
        }
    }

    private void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        //normalized: tra ve 1 Vector2 giá trị bthuong, (tim hieu them tren unity)
        pushDirection *= pushBackForce;

        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;// Vector2.zero = (0, 0);
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);// ForceMode2D.Impulse: Them 1 luc lap tuc cho vat bay len

    }
}
