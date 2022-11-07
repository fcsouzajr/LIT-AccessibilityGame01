using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteFallTimer : MonoBehaviour {

	public float fallSpeed = 4.0f;
	[SerializeField]private bool CanFall;
	public float TimeBeforeFall = 5;
	
	void Start()
	{
		StartCoroutine(ReadyToFall());
	}

	void Update()
	{
		if(CanFall == true)
		{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		} 
	}
	
	IEnumerator ReadyToFall ()
	{
		CanFall = false;
		yield return new WaitForSeconds(TimeBeforeFall);
		
		CanFall = true;
	}
}

