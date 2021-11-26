using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float dieTime;
    public float damage;
    public GameObject diePEDDECt;
    Player_Health playerHealth;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
        playerHealth = FindObjectOfType<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            Die();
            Debug.Log("Trúng tên ");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
            playerHealth.addDamage(damage);
            // isDMG = false;
            //playerHealth.playerHealthSlider.value = playerHealth.maxHealth;
            //Debug.Log("Đã trúng Player" + playerHealth.maxHealth);


        }
    }
    void Die()
    {
        Destroy(gameObject);

    }
    public IEnumerator damage_cung()
    {
        yield return new WaitForSeconds(0.5f);
        playerHealth.maxHealth -= damage;
       // isDMG = false;
        playerHealth.playerHealthSlider.value = playerHealth.maxHealth;
    }
}
