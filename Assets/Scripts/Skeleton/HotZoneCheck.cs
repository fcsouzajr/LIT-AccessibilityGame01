using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour {

	private Skeleton enemyParent;
	private bool inRange;
	[HideInInspector] public Animator anim;

	private void Awake()
	{
		enemyParent = GetComponentInParent<Skeleton>();
		anim = GetComponentInParent<Animator>();
	}

	private void Update()
	{
		if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
		{
			enemyParent.Flip();
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			inRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.CompareTag("Player"))
		{
			inRange = false;
			gameObject.SetActive(false);
			enemyParent.triggerArea.SetActive(true);
			enemyParent.inRange = false;
			anim.SetBool("canWalk", false);
			anim.SetInteger("Idle", 0);
		}
	}
}
