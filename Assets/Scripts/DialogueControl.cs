using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {

    [Header("Components")]
    public GameObject dialogueObj;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        foreach (var letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length -1)//há texto no array
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());//chama a próxima sentença
            }else
            {
                speechText.text = "";
                index=0;
                dialogueObj.SetActive(false);
            }
        }
    }
}
