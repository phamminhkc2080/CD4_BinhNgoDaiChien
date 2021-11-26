using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiChuyen : MonoBehaviour
{
    public GameObject mau;

    public float speed;
    //public float distance;// detection distance

    private bool moveRight = true;

    public Transform groundDetection;//point of enemy, diem phat hien va cham
    //public Player p;
    public GameObject plr;// object player

    private bool move = true;
    //private bool isDMG = false;
    public float atkDis = 1.5f;//Khoang cach

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move) transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0);
        /* RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance = Mathf.Infinity);
         * origin	: The point in 2D space where the ray originates.
         * direction:	A vector representing the direction of the ray.
         * distance : The maximum distance over which to cast the ray.
         */

        if (groundInfo.collider == false)// check va cham colider
        {
            //Debug.Log("Dag ko va cham");

            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
            //Debug.Log("ajskjshdfkj");
        }

        // distance from this position to player position < attack distance
        if (Vector3.Distance(this.transform.position, plr.transform.position) < atkDis)
        {
            move = false; // stop move
            // damage
            /*
             * 
             */
            this.GetComponent<Animator>().SetTrigger("Atk");
            if (moveRight && plr.transform.position.x < this.transform.position.x)
            {
                // Neu player o ben trai => player posion.x < this.position.x
                // Thi quay trai

                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            //Nguoc lai
            if (!moveRight && plr.transform.position.x > this.transform.position.x)
            {
                //Thi quay phai
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
        else
        {
            move = true;
            this.GetComponent<Animator>().SetTrigger("Move");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            //Debug.Log("Toe Mau");
            //this.GetComponent<Animator>().SetTrigger("Die");
            
            StartCoroutine(Delay());
            
        }
    }
    IEnumerator Delay()
    {
        mau.SetActive(true);
        yield return new WaitForSeconds(1f);
        mau.SetActive(false);
    }
    
}
