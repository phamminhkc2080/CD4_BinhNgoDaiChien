using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPickup : MonoBehaviour
{

    public float healthAmount;

    UIManager ui;

    void Start()
    {
        ui = GameObject.FindWithTag("ui").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision: object va cham vs object nay
        if (collision.tag == "Player")
        {
            PlayerHealth thePlayerHealth = collision.gameObject.GetComponent<PlayerHealth> ();

            //check loai object hien tai
            if (this.gameObject.tag == "Blood")
                thePlayerHealth.addHealth(healthAmount);

            if (this.gameObject.tag == "Coin")
            {
                this.gameObject.GetComponent<Animator>().Play("Coin2");
                ui.IncrementCoin();
                ui.SetScore();
            }

            Destroy(gameObject);
        }
    }
}
