using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    float currentHealth;

    public GameObject bloodEffect;

    //kb cac bien UI
    public Slider playerHealthSlider;
    public GameObject pauseMenu;

    PauseMenu pauseMenuUi;

    void Start()
    {
        currentHealth = maxHealth;

        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;

        pauseMenuUi = pauseMenu.GetComponent<PauseMenu>();
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
            makeDead();
    }

    //Tao chuc nang hoi mau an dc vien mau
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        playerHealthSlider.value = currentHealth;
    }

    private void makeDead()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);// animation bloddEffect
        //Destroy(gameObject);
        gameObject.SetActive(false);
        pauseMenuUi.Pause();
    }

    public float getCurrentHealth() { return currentHealth; }
}
