using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
	public float damage;
	private Rigidbody2D rig;

	// void OnTriggerEnter2D(Collider2D collider)
	// {
	// 	if (collider.gameObject.tag == "Player")
	// 	{
	// 		Player.instance.Damage(damage);
	// 	}
	// }
}
