using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string nomedacena;

    public void changeS() {
        SceneManager.LoadScene(nomedacena);
    }

    public void sair()
    {
        Application.Quit();
    }

}
