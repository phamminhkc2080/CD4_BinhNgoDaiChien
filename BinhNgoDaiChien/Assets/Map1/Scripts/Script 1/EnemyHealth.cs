using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    // bien de tao hieu ung khi enemy die

    public GameObject enemyHealthEF;

    //khai bao cac bien de tao thanh mau cho enemy

    public Slider enemyHealthSlider;

    //khai bao item khi enemy chet

    public bool drop;
    public GameObject theDrop;


    UI_Manager ui;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;

        ui = GameObject.FindWithTag("ui").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
        }

    }
    void makeDead()
    {
       // Debug.Log("Enemy die !");
        gameObject.SetActive(false);
        
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
        // roi ra item
        if (drop)
        {
            Instantiate(theDrop, transform.position,transform.rotation);
        }

        if (ui != null)
        {
            // chuc nang tinh diem diet quai
            if (this.gameObject.tag == "Cung")
            {
                ui.IncrementCung();
                ui.SetScore();
            }
            if (this.gameObject.tag == "Kiem")
            {
                ui.IncrementKiem();
                ui.SetScore();
            }
        }

    }
}
