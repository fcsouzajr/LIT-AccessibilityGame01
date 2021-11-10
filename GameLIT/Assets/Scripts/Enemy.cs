using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public float walkTime;
    private float timer; 
    private Rigidbody2D rig;
    private bool walkRight;
    private SpriteRenderer sprite;
    public bool playerDetected;
    public Transform detector1;
    public Transform detector2;
    public LayerMask whatIsPlayer;
    public Transform playerCheck;
    public float playerCheckRadius = 0.68f; 
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        playerDetected = Physics2D.Linecast(detector1.position, detector2.position, whatIsPlayer);
        if (playerDetected)
        {
            print("dale macio"); 
        }

        if(timer >= walkTime)
        {
            walkRight = !walkRight; 
            timer = 0f; 
        }

        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0,180); 
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }

          
        

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
