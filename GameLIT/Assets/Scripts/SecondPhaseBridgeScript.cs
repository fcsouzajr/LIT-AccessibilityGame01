using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhaseBridgeScript : MonoBehaviour {

    public GameObject bridge;
    public bool Activate; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Activate == true)
        {
            bridge.SetActive(true);  
        }else if(collision.gameObject.tag == "Player" && Activate == false)
        {
            bridge.SetActive(false); 
        }
    }




}
