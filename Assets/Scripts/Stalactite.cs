using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
	public float damage;
	public float speed;

	public GameObject estalactite;
	private Rigidbody2D rig;

	// void OnTriggerEnter2D(Collider2D collider)
	// {
	// 	if (collider.gameObject.tag == "Player")
	// 	{
	// 		estalactite.GetComponent<Rigidbody2D>().RigidbodyConstraints2D.None;
	// 	}
	// }
}
