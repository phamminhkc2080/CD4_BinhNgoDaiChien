using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiDiChuyen : MonoBehaviour
{
    
    public float speed;
    //public float distance;// detection distance

    private bool moveRight = true;

    public Transform groundDetection1, groundDetection2;//point of voi, diem phat hien va cham

    public GameObject plr;// object player

    private bool move = true;
    //private bool isDMG = false;

    public float atkDis = 5f;//Khoang cach

    private Animator anim;

    //Khai Bao cac bien de ban
    public Transform Gunpoint;// Vi tri dan duoc ban
    public GameObject bullet;// dan
    float fireRate = 2f;//0.5s ban 1 lan
    float nextFire = 0f;


    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (move)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.Play("Walk");
        }

        RaycastHit2D groundInfo1 = Physics2D.Raycast(groundDetection1.position, Vector2.down, 0);
        RaycastHit2D groundInfo2 = Physics2D.Raycast(groundDetection2.position, Vector2.down, 0);
        /* RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance = Mathf.Infinity);
         * origin	: The point in 2D space where the ray originates.
         * direction:	A vector representing the direction of the ray.
         * distance : The maximum distance over which to cast the ray.
         */

        if ((groundInfo1.collider == false & groundInfo2.collider == false) || (groundInfo1.collider && groundInfo2.collider))
        {
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
        }

        if (Vector3.Distance(this.transform.position, plr.transform.position) < atkDis)
        {
            move = false; // stop move
            anim.Play("Idle");
            
            if (moveRight && plr.transform.position.x < this.transform.position.x)
            {
                // Neu player o ben trai => player posion.x < this.position.x
                // Thi quay trai

                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            //Nguoc lai
            else if (!moveRight && plr.transform.position.x > this.transform.position.x)
            {
                //Thi quay phai
                transform.eulerAngles = new Vector3(0, 0, 0);
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
