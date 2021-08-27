using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Rigidbody2D body;
    SpriteRenderer sprite;
    float moveX = 0;
    bool jumpPressed = false;
    public float speed;
    public float jumpForce;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update() {
        moveX = Input.GetAxis("Horizontal");
        jumpPressed = Input.GetButtonDown("Jump");

        if (moveX != 0)
            Walk();

        if (jumpPressed)
            Jump();

        if (body.velocity.x > 0 && sprite.flipX ||
            body.velocity.x < 0 && !sprite.flipX)
            Flip();
    }

    void Flip() {
        sprite.flipX = !sprite.flipX;
    }

    void Walk() {
        body.velocity = new Vector2(moveX * speed, body.velocity.y);
    }

    void Jump() {
        body.AddForce(new Vector2(0, jumpForce));
    }
}
