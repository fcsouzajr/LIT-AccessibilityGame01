using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Components")]
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;

    [Header("Move Variables")]
    public float speed;
    public float walkTime;
    private float timer;
    private bool walkRight;

    [Header("Player Detecting Variables")]
    public Transform detector1;
    public Transform detector2;
    public bool playerDetected;
    public Transform playerCheck;
    public float playerCheckRadius = 0.68f;
    public LayerMask whatIsPlayer;
    public bool playerIsOnRange;

    [Header("Attack Variables")]
    public float attackDamage;
    public float delayAttackValue;
    private float delayAttack;
    private bool isDead = false;
    public float hp = 30f;
    GameObject player;

    [Header("Ground Detecting Variables")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool willNotFall;

    void Start () {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        delayAttack -= Time.deltaTime;
        playerIsOnRange = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
        playerDetected = Physics2D.Linecast(detector1.position, detector2.position, whatIsPlayer) ? true : playerDetected;
        willNotFall = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (!isDead) {
            if (willNotFall) {
                if (playerDetected) {
                    if (playerIsOnRange) {
                        if (delayAttack <= 0) {
                            delayAttack = delayAttackValue;
                            anim.SetTrigger("attack");
                        }
                    } else if (delayAttack <= 0) {
                        string directionAux = player.transform.position.x > transform.position.x ? "right" : "left";
                        Move(directionAux);
                    }
                } else {
                    if (timer >= walkTime) {
                        walkRight = !walkRight;
                        timer = 0f;
                    }
                    string directionAux = walkRight ? "right" : "left";
                    Move(directionAux);
                }
            } else {
                body.velocity = new Vector2(0f, body.velocity.y);
                playerDetected = false;
                Flip();
            }
        }
        if (body.velocity.x > 0 && !sprite.flipX ||
            body.velocity.x < 0 && sprite.flipX)
            Flip();

        anim.SetFloat("speedX", Mathf.Abs(body.velocity.x));
	}

    void Flip() {
        sprite.flipX = !sprite.flipX;
        playerCheck.localPosition = new Vector2(-playerCheck.localPosition.x, playerCheck.localPosition.y);
        groundCheck.localPosition = new Vector2(-groundCheck.localPosition.x, groundCheck.localPosition.y);
    }

    void Move(string direction) {
        int directionAux = direction == "right" ? 1 : -1;
        body.velocity = new Vector2(directionAux * speed, body.velocity.y);
    }

    void Attack() {
        FindObjectOfType<SFXManager>().Play("EnemyAttack");
        if (playerIsOnRange)
            player.SendMessage("Damage", attackDamage);
    }

    public void Damage(float damage) {
        hp -= hp > damage ? damage : hp;
        if (hp <= 0 && !isDead) {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        isDead = true;
        body.velocity = Vector2.zero;
        anim.SetTrigger("die");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}