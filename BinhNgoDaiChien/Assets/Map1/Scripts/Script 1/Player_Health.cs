using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Health : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject bloodEffect;

    //khai  bao cac bien UI

    public Slider playerHealthSlider;

    public GameObject pauseMenu;

    Pause_Menu pauseMenuUi;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;

        pauseMenuUi = pauseMenu.GetComponent<Pause_Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
        }

        //Debug.Log("ABC: " + currentHealth);
    }

    //tao ra chuc nang hoi mau khi an duoc trai tim
    public void addHealth(float heatthAmount)
    {
        //Debug.Log("Mau1: " + currentHealth);

        //Debug.Log("ADD health: " + (currentHealth + heatthAmount));

        currentHealth += heatthAmount;
        if(currentHealth > maxHealth)
        
            currentHealth = maxHealth;
        playerHealthSlider.value = currentHealth;

        //Debug.Log("Mau2: " + currentHealth);
        //Debug.Log("Them Mau !");
    }
    void makeDead()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        //Destroy(gameObject);

        gameObject.SetActive(false);
        pauseMenuUi.Pause();
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
}
