using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem{
    public class DialogueControl : MonoBehaviour {

        public bool finished{ get; private set;}
        
        protected IEnumerator WriteText(string speech, Text speechHolder, float delay, float delayBetweenLines)
        {
            FindObjectOfType<SFXManager>().Play("KeyboardTyping");
            for (int i = 0; i < speech.Length; i++)
            {
                speechHolder.text += speech[i];
                yield return new WaitForSeconds(delay);
            }
            FindObjectOfType<SFXManager>().Stop("KeyboardTyping");
            yield return new WaitUntil(()=> Input.GetMouseButton(0));
            finished = true;
        }
    }
}