using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public string itemName;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            FindObjectOfType<SFXManager>().Play("Collectable");
            Destroy(gameObject);
            GiveItem();
        }
    }

    void GiveItem() {
        FindObjectOfType<PlayerInventory>().SendMessage("AddItem", itemName);
    }
}
