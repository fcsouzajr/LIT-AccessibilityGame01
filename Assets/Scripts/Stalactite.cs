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
	private void OnCollisionEnter2D(Collision2D collider) {
		//Debug.Log("Entrou");
        if (collider.gameObject.tag == "Player") {
			//Debug.Log("Encostou");
            player.SendMessage("Damage", attackDamage);
        }
    }
}
