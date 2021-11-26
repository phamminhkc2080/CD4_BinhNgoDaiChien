using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float TocDo=0f;
    private float VanToc = 5f;
    private float VanTocMax = 7f;

    private bool DuoiDat=true;
    private bool Jump_up=false;
    private bool Jump_down=false;

    private Rigidbody2D rb;
    private Animator anim;

    private bool QuayPhai = true;
    private float NhayCao = 400;//tốc độ nhảy
    private float RoiXuong = 5;//Lực hút rơi xuống của Player

    //Khai Bao cac bien de ban
    public Transform bowTip;// Vi tri mui ten duoc ban
    public GameObject arrow;// mui ten
    float fireRate = 0.5f;// 0.5s ban 1 lan
    float nextFire = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("DuoiDat", DuoiDat);
        anim.SetFloat("TocDo", TocDo);
        anim.SetBool("Jump_up", Jump_up);
        anim.SetBool("Jump_down", Jump_down);

        Nhay();
    }

    private void Nhay()
    {
        if (Input.GetKeyDown(KeyCode.L) && DuoiDat)
        {
            rb.AddForce(Vector2.up * NhayCao);
            DuoiDat = false;
            Jump_up = true;
        }

        if (rb.velocity.y < 0)
        {
            Jump_up = false;
            Jump_down = true;

            //Áp dụng lực hút cho Player rơi xuống nhanh hơn
            rb.velocity += Vector2.up * Physics2D.gravity.y * (RoiXuong - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y>0 && !Input.GetKey(KeyCode.L)) //Chỉ cho Player nhảy thấp
        {
            /* nghĩa là chỉ nhấp nhả thì sẽ nhày thấp, nhấp giữ mới nhảy cao
            bấm phát nhả luôn thì set cho mario rơi xuống luôn, bình thường bấm 1 phát
            Mario sẽ nhảy cao hết cỡ rồi mới rơi xuống.
            */
            rb.velocity += Vector2.up * Physics2D.gravity.y * (RoiXuong - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        DiChuyen();
        if (Input.GetKey(KeyCode.K))
        {
            ShootArrows();
        }
    }

    private void ShootArrows()
    {
        if (Time.time > nextFire)//time hien tai > time lan ban tiep theo
        {
            nextFire = Time.time + fireRate;

            if(DuoiDat) anim.Play("Attack_stand");
            else anim.Play("Attack_jump");

            if (QuayPhai)
            {
                Instantiate(arrow, bowTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }else if (!QuayPhai)
            {
                Instantiate(arrow, bowTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                //Quaternion.Euler: giu nguyen truc x va y, quay truc z 180 do;
            }
        }
    }

    private void DiChuyen()
    {
        /*Chọn phím di chuyển cho player (Phím <- và -> hoặc A hay D)
         *GetAxisRow khi bấm trả về giá trị -1 0 1
         *GetAxis  nó sẽ nhận -1 0 1; nó chạy từ 0 về -1 hoặc 0 nên 1
         */

        float PhimNhanTraiPhai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(VanToc * PhimNhanTraiPhai, rb.velocity.y);
        TocDo = Mathf.Abs(VanToc * PhimNhanTraiPhai);

        if (PhimNhanTraiPhai > 0 && !QuayPhai) HuongQuayMat();
        if (PhimNhanTraiPhai < 0 && QuayPhai) HuongQuayMat();
    }

    private void HuongQuayMat()
    {
        QuayPhai = !QuayPhai;

        Vector2 HuongQuay = transform.localScale;
        HuongQuay.x *= -1;
        transform.localScale = HuongQuay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Box")
        {
            DuoiDat = true;
            Jump_down = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Box")
        {
            DuoiDat = true;
            Jump_down = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            transform.SetParent(collision.gameObject.transform);

            //Debug.Log("Đã đứng trên box");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Box"))
        {
            transform.SetParent(null);
        }
    }
}
