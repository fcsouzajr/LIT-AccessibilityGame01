﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour {

    [Header("Components")]
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;

    [Header("Move Variables")]
    public float speed;

    [Header("Player Detecting Variables")]
    public Transform playerCheck;
    public float playerCheckRadius;
    public LayerMask whatIsPlayer;
    public bool playerIsOnRange;

    [Header("Attack Variables")]
    public float attackDamage;
    public float delayAttackValue;
    private float delayAttack;
    GameObject player;

    [Header("Health Variables")]
    public float maxHP;
    public float HP;
    public Slider HPBar;
    private bool isDead = false;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        HP = maxHP;
        HPBar.maxValue = maxHP;
        HPBar.value = HP;
    }

    void FixedUpdate() {
        delayAttack -= Time.deltaTime;
        playerIsOnRange = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);

        if (!isDead) {
            if (playerIsOnRange) {
                if (delayAttack <= 0) {
                    delayAttack = delayAttackValue;
                    anim.SetTrigger("attack");
                }
            } else if (delayAttack <= 0) {
                string directionAux = player.transform.position.x > transform.position.x ? "right" : "left";
                Move(directionAux);
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
        HP -= HP > damage ? damage : HP;
        HPBar.value = HP;

        if (HP <= 10) {
            StartCoroutine(FindObjectOfType<Transition>().BossDefeatTransition());
        }

        if (HP <= 0 && !isDead) {
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
    }


}
