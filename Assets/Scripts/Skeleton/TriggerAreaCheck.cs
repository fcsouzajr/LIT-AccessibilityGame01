using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour {

	private Skeleton enemyParent;

	private void Awake()
	{
		enemyParent = GetComponentInParent<Skeleton>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			gameObject.SetActive(false);
			enemyParent.target = collider.transform;
			enemyParent.inRange = true;
			enemyParent.hotZone.SetActive(true);
		}
	}
}