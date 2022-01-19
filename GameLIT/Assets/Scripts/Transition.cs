using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    Animator anim;

    private void Start() {
        anim = gameObject.GetComponent<Animator>();
    }

    public IEnumerator DeathTransition(float startDelay) {
        yield return new WaitForSeconds(startDelay);
        anim.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator BossDefeatTransition() {
        anim.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
}
