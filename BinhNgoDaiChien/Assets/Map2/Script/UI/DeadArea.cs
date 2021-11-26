using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArea : MonoBehaviour
{

    public GameObject player;
    

    PlayerHealth playerHealthUi;
    

    void Start()
    {
        playerHealthUi = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealthUi.addDamage(playerHealthUi.getCurrentHealth());
            //Debug.Log("Đã vào vùng chết "+ playerHealthUi.getCurrentHealth());
        }
    }
}
