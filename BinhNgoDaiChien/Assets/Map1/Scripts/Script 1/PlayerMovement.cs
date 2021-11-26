using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
     SpriteRenderer sprite;
    Animator anim;

    private BoxCollider2D coll;

    float dirX = 0f;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    bool facingRight;

    private enum MovementState
    {
        idle,running,jumping,falling
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.isActive)
        {
            anim.Play("NoneActive");
            return;
        }

         dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.L) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("check " + IsGrounded());
        }
        Debug.Log("check 1 " + IsGrounded());

        UpdateAnimationState();
    }
    
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f )
        {
            state = MovementState.running;

            Flip(dirX);
        }
        else if (dirX < 0f )
        {
            state = MovementState.running;

            Flip(dirX);
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y> .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private void Flip(float horizontal)
    {
        // kiểm tra trạng thát hiện tại của player
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1f;
            transform.localScale = theScale;
        }
    }
    private bool IsGrounded()
    {
      return  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
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
