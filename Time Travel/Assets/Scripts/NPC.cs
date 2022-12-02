using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Move")]


    [Header("Interaccion")]
    public KeyCode Interactuar;
    public bool canTalk;
    public Dialogue dialogue;
    public GameObject dialogueManager;
    public GameObject Player;
    public bool InDialogue;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collision)
    {
        

        if (collision.transform.tag == "Player")
        {
            if(InDialogue)
            {
                collision.gameObject.GetComponent<Player>().Stop(false);
            }
                
            //Player.GetComponent<Player>().InConversation = true;

            Debug.Log("Contacto");
             canTalk = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            InDialogue = false;
            canTalk = false;
            FindObjectOfType<DialogueManager>().end();
            
            
        }
        
    }
    void Update()
    {
        if (canTalk)
        {
            if (Input.GetKeyDown(Interactuar))
            {

                InDialogue = true;
                bool finished = dialogueManager.GetComponent<DialogueManager>().DisplaySigOracion();
                Player.GetComponent<Player>().Stop(finished);

            }
        }
    }
}
