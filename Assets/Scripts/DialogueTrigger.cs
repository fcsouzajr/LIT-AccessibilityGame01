using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

    public GameObject dialogueBox;
    public Text textLabel;

    [TextArea(2,5)]
    public string dialogueText;

    private void Start() {
        textLabel.text = string.Empty;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            dialogueBox.SetActive(true);
            StartCoroutine(TypeSentence());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            dialogueBox.SetActive(false);
            textLabel.text = "";
            StopAllCoroutines();
        }
    }

    IEnumerator TypeSentence() {
        foreach (char letter in dialogueText.ToCharArray()) {
            textLabel.text += letter;
            yield return null;
        }
    }
}
