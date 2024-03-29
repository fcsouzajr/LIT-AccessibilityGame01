﻿using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBehaviour : MonoBehaviour {

    [Header("UI")]
    //private Image hpBar;
    private float hp = 100f;
    bool isDead = false;
    
    public float maxHP;
    public float HP;
    public Slider HPBar;
    

    [Header("Components")]
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;

    [Header("Jump Variables")]
    public float jumpVelocity;
    public float fallMultiplier;
    public float groundCheckRadius;
    bool isOnFloor;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    [Header("Move Variables")]
    public float speed;
    float moveX = 0;
    float delayAtackValue = 0.3f;
    float delayAttack = 0;
    public bool canInteract = true;

    [Header("Attack Variables")]
    public float attackDamage;
    public Transform enemyCheck;
    public float enemyCheckRadius;
    public LayerMask whatIsEnemy;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        if (!isDead && canInteract) {
            moveX = Input.GetAxis("Horizontal");
            isOnFloor = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

            if (Input.GetButtonDown("Fire1") && isOnFloor)
                anim.SetTrigger("attack");

            if (body.velocity.y < 0)
                body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && isOnFloor)
                Jump();

            if (moveX != 0 && delayAttack <= 0)
                Walk();

            if (moveX > 0 && sprite.flipX ||
                moveX < 0 && !sprite.flipX)
                Flip();

            if (Input.GetKeyDown("l"))
                hp += 200f;

            delayAttack -= (delayAttack > 0) ? Time.deltaTime : 0;
        }

        SetAnim();
    }

    void Flip() {
        sprite.flipX = !sprite.flipX;
        enemyCheck.localPosition = new Vector2(-enemyCheck.localPosition.x, enemyCheck.localPosition.y);
    }

    void Walk() {
        if(delayAttack <= 0)
            body.velocity = new Vector2(moveX * speed, body.velocity.y);
    }

    void Jump() {
        if (delayAttack <= 0) {
            FindObjectOfType<SFXManager>().Play("PlayerJump");
            body.velocity = Vector2.up * jumpVelocity;
        }
    }

    void SetAnim() {
        anim.SetFloat("speedX", Math.Abs(body.velocity.x));
        anim.SetFloat("speedY", body.velocity.y);
    }

    void Attack() {
        FindObjectOfType<SFXManager>().Play("PlayerAttack");
        delayAttack = delayAtackValue;
        body.velocity = Vector2.right * 0;

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(enemyCheck.position, enemyCheckRadius, whatIsEnemy);
        for(int i = 0; i < enemiesInRange.Length; i++) {
            //Debug.Log("Achou enemy");
            enemiesInRange[i].SendMessageUpwards("Damage", attackDamage);
        }
    }

    public void Damage(float damage) {
        HP -= HP > damage ? damage : HP;
        HPBar.value = HP;
        if (HP <= 0 && !isDead) {
            Die();
        }
    }

    void Die() {
        isDead = true;
        body.velocity = Vector2.zero;
        anim.SetTrigger("die");
        StartCoroutine(FindObjectOfType<Transition>().DeathTransition(1f));
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(enemyCheck.position, enemyCheckRadius);
    }
}
