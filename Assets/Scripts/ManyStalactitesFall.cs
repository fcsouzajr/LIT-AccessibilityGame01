using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyStalactitesFall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{

			StartCoroutine(fall());
		}
	}

	IEnumerator fall()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			yield return new WaitForSeconds(0.1f);;
		}
	}
}
