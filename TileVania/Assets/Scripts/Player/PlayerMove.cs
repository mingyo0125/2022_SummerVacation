using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] float climbSpeed;
    [SerializeField] Vector2 deathKick = new Vector2 (15f, 15f);
    [SerializeField] GameObject hazards_Sound;
    [SerializeField] GameObject jump_Sound;

    Rigidbody2D rb;
    Animator animator;

    bool facingRight;
    bool isGround;
    bool isLadder;
    bool isAlive = true;
    float delay = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        float _life = PlayerPrefs.GetFloat("live");
        if(!isAlive || rb.IsTouchingLayers(LayerMask.GetMask("Exit")))
        {
            return;
        }

        Move();
        Jump();
        climb();
        Die();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h,0,0);
        transform.position += dir * speed * Time.deltaTime;
        

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("IsRunning", true);
            if(!facingRight)
            {
                Vector3 curScale = transform.localScale;
                curScale.x *= -1;
                transform.localScale = curScale;
                facingRight = !facingRight;
            }
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("IsRunning", true);
            if(facingRight)
            {
                Vector3 curScale = transform.localScale;
                curScale.x *= -1;
                transform.localScale = curScale;
                facingRight = !facingRight;
            }      
        }
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        if(isGround == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(jump_Sound);
                rb.velocity += new Vector2 (0, jumpPower);
                isGround = false;
            }
        }
    }

    void climb()
    {
        if(isLadder == true)
        {
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("IsClimbing", true);
            }
            float v = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(0,v,0);
            transform.position += dir * speed * Time.deltaTime;
            rb.gravityScale = 0;
        }
    }

    void Die()
    {
        if(rb.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            Instantiate(hazards_Sound);
            isAlive = false;
            animator.SetTrigger("Die");
            rb.velocity = deathKick;
            Invoke("_GameSession", delay);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if(other.gameObject.CompareTag("Bounce"))
        {
            Instantiate(jump_Sound);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            isGround = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            rb.gravityScale = 5;
            animator.SetBool("IsClimbing", false);
        }
    }

    void _GameSession()
    {
        FindObjectOfType<GameSession>().PlayerDeath();
    }
}
