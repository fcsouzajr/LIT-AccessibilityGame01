using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhaseBridgeScript : MonoBehaviour {

    public GameObject bridge;
    public bool Activate; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bridge.SetActive(true);  
        }
    }




}
