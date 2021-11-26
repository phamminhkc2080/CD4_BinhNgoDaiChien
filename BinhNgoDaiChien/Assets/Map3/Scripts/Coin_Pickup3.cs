using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Pickup3 : MonoBehaviour
{
    UIManager3 ui;

    void Start()
    {
        ui = GameObject.FindWithTag("ui").GetComponent<UIManager3>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision: object va cham vs object nay
        if (collision.tag == "Player")
        {
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
