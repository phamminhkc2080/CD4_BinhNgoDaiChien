using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThaVoi : MonoBehaviour
{

    private GameObject boss;
    private BossHealth bossHealth;


    public float speed;
    public int damage;

    private bool moveRight = true;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossHealth = boss.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(moveRight && boss.transform.position.x < this.transform.position.x)
        {
            // Neu boss o ben trai => boss posion.x < this.position.x
            // Thi quay trai

            transform.eulerAngles = new Vector3(0, -180, 0);
            moveRight = false;
        }else if(!moveRight && boss.transform.position.x > this.transform.position.x)
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
            moveRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            bossHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
