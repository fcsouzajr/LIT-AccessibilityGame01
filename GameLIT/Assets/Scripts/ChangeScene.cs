using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string nome_da_cena;

    public void changeS(string nomeCena) {
        SceneManager.LoadScene(nomeCena);
    }

    public void sair()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            changeS(nome_da_cena); 
        }
    }
}
