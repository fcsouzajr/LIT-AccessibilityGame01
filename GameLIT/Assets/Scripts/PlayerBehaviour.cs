using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

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

    void Start() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        moveX = Input.GetAxis("Horizontal");
        isOnFloor = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (body.velocity.y < 0)
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1) * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isOnFloor)
            Jump();

        if (moveX != 0)
            Walk();

        if (moveX > 0 && sprite.flipX ||
            moveX < 0 && !sprite.flipX)
            Flip();

        SetAnim();
    }

    void Flip() {
        sprite.flipX = !sprite.flipX;
    }

    void Walk() {
        body.velocity = new Vector2(moveX * speed, body.velocity.y);
    }

    void Jump() {
        body.velocity = Vector2.up * jumpVelocity;
    }

    void SetAnim() {
        anim.SetFloat("speedX", Math.Abs(body.velocity.x));
        anim.SetFloat("speedY", body.velocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
