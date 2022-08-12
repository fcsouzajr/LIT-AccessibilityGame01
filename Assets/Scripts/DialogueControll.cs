using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {

    [Header("Componentes")]
    public GameObject dialogueObj;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    public void Speech(string txt, string actorName)
    {
        dialogueObj.SetActive(true);
        speechText.text = txt;
        actorNameText.text = actorName;
    }
}
