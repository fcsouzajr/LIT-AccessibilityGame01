using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMechanism : MonoBehaviour {

	public GameObject bridge; 

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player"){
            bridge.transform.position = new Vector3(33.024f, -5.114f, 0.0f);
            //bridge.transform.rotation = Vector3.zero;
            bridge.transform.eulerAngles = Vector3.zero;
        }
	}
}