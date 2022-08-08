﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallKiller : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player")
            StartCoroutine(FindObjectOfType<Transition>().DeathTransition(0));
    }
}