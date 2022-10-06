using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteFall : MonoBehaviour {

	[Header("Components")]
	public GameObject estalactite;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			estalactite.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		}
	}
}
