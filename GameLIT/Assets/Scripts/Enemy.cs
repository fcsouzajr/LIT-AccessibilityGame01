using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    public float walkTime;
    private float timer; 
    private Rigidbody2D body;
    private bool walkRight;
    private SpriteRenderer sprite;
    public bool playerDetected;
    public Transform detector1;
    public Transform detector2;
    public LayerMask whatIsPlayer;
    public Transform playerCheck;
    public float playerCheckRadius = 0.68f;
    public GameObject player;
    public bool playerIsInside;
    public Animator anim;
    public float delayAttackValue;
    public float delayAttack;

    void Start () {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        delayAttack -= Time.deltaTime; 
        playerDetected = Physics2D.Linecast(detector1.position, detector2.position, whatIsPlayer);
        playerIsInside = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
        if (playerDetected) {

            if (playerIsInside && delayAttack <= 0)
            {
                delayAttack = delayAttackValue; 
                anim.SetTrigger("attack"); 
            }
            else if(!playerIsInside)
            {  
                if (player.transform.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    body.velocity = Vector2.left * speed;
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, 180);
                    body.velocity = Vector2.right * speed;
                }
            }
        } else {
            if(timer >= walkTime) {
                walkRight = !walkRight; 
                timer = 0f; 
            }

            if (walkRight) {
                transform.eulerAngles = new Vector2(0,180); 
                body.velocity = Vector2.right * speed;
            } else {
                transform.eulerAngles = new Vector2(0, 0);
                body.velocity = Vector2.left * speed;
            }

        }

        anim.SetFloat("speedX", Mathf.Abs(body.velocity.x));
	}

    void Flip()
    {
        sprite.flipX = !sprite.flipX; 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
    }


}
