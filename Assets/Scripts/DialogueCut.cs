using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCut : MonoBehaviour {

    public string speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;
	
	private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if(hit != null)
        {
            dc.Speech(speechTxt, actorName);
        }
    }
}
