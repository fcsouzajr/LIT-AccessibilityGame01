using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
	[Header("Attack Variables")]
    public float attackDamage;
	GameObject player;

	void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	private void OnTriggerStay2D(Collider2D collider) {
        if(collider is CapsuleCollider2D){
            if (collider.gameObject.tag == "Player") {
                player.SendMessage("Damage", attackDamage);
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.layer == 9) {
            Destroy(gameObject, 1.5f);
        }
    }
}
