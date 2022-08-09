using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    //Variável string que irá guardar o "nome da cena" a qual se quer seguir
    public string nome_da_cena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Se o objeto com a tag "player" adentrar
        if (collision.gameObject.tag == "Player")
        {
            changeS(nome_da_cena); 
        }
    }

    public void changeS(string nomeCena) {
        SceneManager.LoadScene(nomeCena);
    }

    //Sai da cena atual
    public void sair()
    {
        Application.Quit();
    }
}
