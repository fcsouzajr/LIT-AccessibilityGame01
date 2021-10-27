using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeDrop : MonoBehaviour {

    // Animator anim;
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
            anim.SetTrigger("fall");
    }
}
