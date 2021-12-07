using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject textoPausa;


    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                textoPausa.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                textoPausa.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}
}
