using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float weaponDamage;

    //public float aliveTime = 5;

    public float arrowSpeed = 2;// Toc do ban

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // ForceMode2D.Impulse: thêm ngay vào mũi tên 1 lực lập tức bay đi
        // new Vector2(1, 0) : là bay về bên phải
        if (transform.localRotation.z > 0) // z > 0 tức là mũi tên đang quay bên trái
        {
            rb.AddForce(new Vector2(-1, 0) * arrowSpeed, ForceMode2D.Impulse);
        }
        else // z==0 tức là mũi tên đang quay bên phải
        {
            rb.AddForce(new Vector2(1, 0) * arrowSpeed, ForceMode2D.Impulse);
        }
    }

    void Start()
    {
        //sDestroy(gameObject, aliveTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shootable" || collision.tag=="Voi" || collision.tag=="OcSen")
        {
            Destroy(gameObject);
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Shootable")
        {
            Destroy(gameObject);
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
