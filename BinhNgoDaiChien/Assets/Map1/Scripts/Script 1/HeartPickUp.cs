using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{

    public float healthAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player_Health playerHealth = collision.gameObject.GetComponent<Player_Health>();
            playerHealth.addHealth(healthAmount);


            Destroy(gameObject);
            
        }
    }
}
