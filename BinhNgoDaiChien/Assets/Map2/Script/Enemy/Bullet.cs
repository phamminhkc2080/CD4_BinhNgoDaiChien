using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    public float aliveTime = 5;

    public float bulletSpeed = 2;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // ForceMode2D.Impulse: thêm ngay vào mũi tên 1 lực lập tức bay đi
        // new Vector2(1, 0) : là bay về bên phải
        if (transform.localRotation.z > 0) // z > 0 tức là mũi tên đang quay bên trái
        {
            rb.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else // z==0 tức là mũi tên đang quay bên phải
        {
            rb.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    void Start()
    {
        Destroy(gameObject, aliveTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);

            PlayerHealth thePlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            
        }
    }
}
