using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{

    public float maxHealth;
    float currentHealth;

    //Bien de tao hieu ung khi enemy die
    public GameObject enemyHealthEF;

    // Khai bao cac bien de tao thanh mau cho enemy
    public Slider enemyHealthSlider;

    //kb cac bien de khi enemy chet se roi ra vat pham
    public bool drop;
    public GameObject theDrop;//vat pham roi ra khi chet

    UIManager ui;

    public void Start()
    {
        currentHealth = maxHealth;

        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;

        ui = GameObject.FindWithTag("ui").GetComponent<UIManager>();
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
            makeDead();
    }

    private void makeDead()
    {
        
        Instantiate(enemyHealthEF, transform.position, transform.rotation);// animation bloddEffect
        // chuc nang roi ra vat pham
        if (drop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }

        // chuc nang tinh diem diet quai
        if (this.gameObject.tag == "Voi")
        {
            ui.IncrementVoi();
            ui.SetScore();
        }
        if (this.gameObject.tag == "OcSen")
        {
            ui.IncrementOcSen();
            ui.SetScore();
        }

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

}
