using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcDiChuyen : MonoBehaviour
{
    public float speed;
    //public float distance;// detection distance

    private bool moveRight = false;

    public Transform groundDetection1, groundDetection2;//point of voi, diem phat hien va cham

    public GameObject plr;

    private bool move = true;

    public float atkDis = 3f;

    //Khai Bao cac bien de ban
    public Transform Gunpoint;// Vi tri dan duoc ban
    public GameObject bullet;// dan
    float fireRate = 2f;//0.5s ban 1 lan
    float nextFire = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move) transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo1 = Physics2D.Raycast(groundDetection1.position, Vector2.down, 0);
        RaycastHit2D groundInfo2 = Physics2D.Raycast(groundDetection2.position, Vector2.down, 0);
        /* RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance = Mathf.Infinity);
         * origin	: The point in 2D space where the ray originates.
         * direction:	A vector representing the direction of the ray.
         * distance : The maximum distance over which to cast the ray.
         */

        if ((groundInfo1.collider == false & groundInfo2.collider==false) || (groundInfo1.collider && groundInfo2.collider))
        {

            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = false;
            }
            else
            {
                
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = true;
            }
        }

        if(Vector3.Distance(this.transform.position, plr.transform.position) < atkDis)
        {
            move = false;// Stop move
            //damge

            //
            
            if(moveRight && plr.transform.position.x < this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

                moveRight = false;
            }
            else if (!moveRight && plr.transform.position.x > this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                
                moveRight = true;
            }else Shoot();

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
            this.GetComponent<Animator>().Play("MatMau");
        }
    }

    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (moveRight)
            {
                Instantiate(bullet, Gunpoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!moveRight)
            {
                Instantiate(bullet, Gunpoint.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
