using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool mustPatrol;
    public float walkSpeed;
    public float range;
    public float timeBTWShot;
    public float shootSpeed;

    private bool mustTurn;
    private bool canShoot;
    private float distToPlayer;


    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    public Transform player;
    public Transform shootPos;
    public GameObject bullet;
    public Animator myAnim;

    // new Variable
    float speed=2;
    void Start()
    {
        mustPatrol = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);
        // kiểm tra khoảng địch với nhân vật
        if(distToPlayer<= range)
        {   
            if(player.position.x>transform.position.x && transform.localScale.x <0 ||
                player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;
            if(canShoot)
            StartCoroutine(Shoot());
        }
        else
        {
            mustPatrol = true;
        }
    }
    //Xử lý vật lý
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            // kiểm tra nếu k chạm mặt đất
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        // va chạm hộp với groundLayer
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        //rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

        myAnim.SetTrigger("Walk_Cung");
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
     void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.lossyScale.x * -1, transform.lossyScale.y);
        walkSpeed *= -1;
        speed *= -1;
        mustPatrol = true;
    }
    IEnumerator Shoot()
    {
        myAnim.SetTrigger("Attack_Cung");
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShot);

        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        
        Vector2 vt = newBullet.transform.localScale;
        if (transform.localScale.x < 0) // dang o ben phai
        {
            vt.x *= -1;
            newBullet.transform.localScale = vt;
        }

        canShoot = true;

    }
}
