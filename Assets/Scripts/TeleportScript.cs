using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

    public string triggerButton;
    public Vector2 destination = new Vector2();

    private void OnTriggerStay2D(Collider2D collision) {
        if(Input.GetButtonDown(triggerButton)) {
            if(collision.gameObject.tag == "Player") {
                Teleport(collision.gameObject);
            }
        }
    }

    void Teleport(GameObject player) {
        player.transform.position = destination;
    }
}
