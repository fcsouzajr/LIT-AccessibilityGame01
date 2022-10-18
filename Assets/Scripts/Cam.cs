using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
	// private Transform player;
	// public float smooth;

	// void Start()
	// {
	// 	player = GameObject.FindGameObjectWithTag("Player").transform;
	// }
	
	// void FixedUpdate()
	// {
	// 	if(player.position.x >= -1.6)
	// 	{
	// 		Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
	// 		transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
	// 	}	
	// }

	public Transform target;
	public float smoothSpeed;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate()
	{
		Vector3 startPosition = new Vector3(target.position.x, (target.position.y + 1.5f), -1f);
		Vector3 smoothPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
		transform.position = smoothPosition;
	}
}
