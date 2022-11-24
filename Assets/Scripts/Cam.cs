using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
	public Transform target;
	public float smoothSpeed;
	public float altura_camera = 2f;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate()
	{
		Vector3 startPosition = new Vector3(target.position.x, (target.position.y + altura_camera), -1f);
		Vector3 smoothPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
		transform.position = smoothPosition;
	}
}
