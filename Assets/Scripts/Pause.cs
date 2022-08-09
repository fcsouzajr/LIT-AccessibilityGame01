using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject textoPausa;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Se o tempo do jogo estiver "Normal" (1): mostre
            // o texto pausa, e desacelere o jogo
            if(Time.timeScale == 1)
            {
                textoPausa.SetActive(true);
                Time.timeScale = 0;
            }
            // Se o tempo do jogo estiver "Pausado" (0): desative
            // o texto pausa, e retorne o jogo à velocidade normal
            else
            {
                textoPausa.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}
}
