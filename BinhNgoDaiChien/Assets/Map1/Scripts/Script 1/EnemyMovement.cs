using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    bool moviRight = true;
    public Transform grounDetection1, grounDetection2;
    public GameObject plr;

    public float attackEnemy;
    bool move = true;
    bool isDMG = false;

    public float atkDis = 1.5f;
    private Player_Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo1 = Physics2D.Raycast(grounDetection1.position, Vector2.down, 0);
        RaycastHit2D groundInfo2 = Physics2D.Raycast(grounDetection2.position, Vector2.down, 0);

        //if (groundInfo2.collider.tag=="Player")
        //{
        //    Debug.Log("Phat hien Player");
        //}

        if ((groundInfo1.collider == false & groundInfo2.collider == false) 
            || (groundInfo1.collider && groundInfo2.collider && groundInfo2.collider.tag!="Player"))
        {
            if (moviRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moviRight = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moviRight = true;
            }
        }

        if (Vector3.Distance(this.transform.position, plr.transform.position) < atkDis)
        {
            move = false;
            if (!isDMG)
            {
                playerHealth.addDamage(attackEnemy);
                isDMG = true;
            }
            this.GetComponent<Animator>().SetTrigger("Attack");
            if(moviRight && plr.transform.position.x < this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moviRight = false;
            }
            if(!moviRight && plr.transform.position.x > this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moviRight = true;
            }
           
        }
        //this.GetComponent<Animator>().SetTrigger("Move");
        else
        {
            move = true;
            this.GetComponent<Animator>().SetTrigger("Move");
        }
    }

    //public IEnumerator damage()
    //{
    //    yield return new WaitForSeconds(0.5f);

    //}
}
