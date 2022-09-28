using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DialogueSystem{
	public class DialogueHolder : MonoBehaviour {
		private void Awake()
		{
			StartCoroutine(dialogueSequence());
		}
		private IEnumerator dialogueSequence()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				Deactivate();
				transform.GetChild(i).gameObject.SetActive(true);
				yield return new WaitUntil(()=> transform.GetChild(i).GetComponent<DialogueLine>().finished);
			}
			//gameObject.SetActive(false);
			gameObject.transform.localScale = new Vector3(0, 0, 0);
		}
		private void Deactivate()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}