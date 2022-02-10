using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text textLabel;
    public string[] sentences;

    private int index = 0;

    void Start () {
        FindObjectOfType<PlayerBehaviour>().canInteract = false;
        textLabel.text = string.Empty;
        dialogueBox.SetActive(true);

        StartCoroutine(TypeSentence());
    }

    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            if (textLabel.text == sentences[index]) {
                SkipSentence();
            } else {
                StopAllCoroutines();
                textLabel.text = sentences[index];
            }
        }
	}

    void SkipSentence() {
        if (index < sentences.Length - 1) {
            index++;
            textLabel.text = string.Empty;
            StartCoroutine(TypeSentence());
        } else {
            FindObjectOfType<PlayerBehaviour>().canInteract = true;
            dialogueBox.SetActive(false);
        }
    }

    IEnumerator TypeSentence() {
        yield return null;
        foreach (char letter in sentences[index].ToCharArray()) {
            textLabel.text += letter;
            yield return new WaitForSeconds(0f);
        }
    }
}
