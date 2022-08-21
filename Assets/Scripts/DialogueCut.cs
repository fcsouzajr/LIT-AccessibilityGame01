using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCut : MonoBehaviour {

    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;
    bool onRadious;

    private DialogueControl dc;
	
	private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }
    private void FixedUpdate()
    {
        Interact();
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space) && onRadious)
        if(onRadious)
        {
            dc.Speech(speechTxt, actorName);
        }
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if(hit != null)//collision detected
        {
            onRadious = true;
        }else
        {
            onRadious = false;
        }
    }
}
