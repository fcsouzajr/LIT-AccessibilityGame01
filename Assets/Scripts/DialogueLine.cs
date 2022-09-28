using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueControl {
        private Text speechHolder;

        [Header("Text option")]
        [SerializeField]private string speech;
        [SerializeField]private GameObject actorName;

        [Header("Time parameter")]
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;

        private void Awake()
        {
            actorName.SetActive(true);
            speechHolder =  GetComponent<Text>();
            speechHolder.text = "";
        }
        private void Start()
        {
            StartCoroutine(WriteText(speech, speechHolder, delay, delayBetweenLines));
        }
        
    }
}