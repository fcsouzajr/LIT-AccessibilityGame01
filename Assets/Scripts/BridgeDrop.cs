using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeDrop : MonoBehaviour {

    public string itemRequired;
    Animator anim;
    PlayerInventory inventory;

    void Start() {
        anim = GetComponent<Animator>();
        inventory = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (inventory.CheckFor(itemRequired)) {
                anim.SetTrigger("fall");
                inventory.RemoveItem(itemRequired);
            }
        }
    }
}
