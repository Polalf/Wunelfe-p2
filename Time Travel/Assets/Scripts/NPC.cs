using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Move")]
    public float speed;
    public float currentSpeed;
    public Transform PointA, PointB, PointC;
    public bool Move;
    public int Target;
    public float TiempoEspera;
    public float Espera;
    private bool Ida;


    [Header("Interaccion")]
    public KeyCode Interactuar;
    public bool canTalk;
    public Dialogue dialogue;
    public GameObject dialogueManager;
    public GameObject Player;
    public bool InDialogue;

    private void Start()
    {
        Ida = true;
        Target = 1;
        Espera = TiempoEspera;
        Move = true;
        currentSpeed = speed;
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
        if(InDialogue)
        {
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = speed;
        }


        // move
        if( Target == 1 && Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, currentSpeed * Time.deltaTime);
            if(transform.position == PointA.position)
            {
                Ida = true;
                Target = 2;
                Move = false;
                Espera = 0;

            }
        }
        else if (Target == 2 && Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, currentSpeed * Time.deltaTime);
            if (Ida)
            {
                if (transform.position == PointB.position)
                {
                    Target = 3;
                    Move = false;
                    Espera = 0;
                }

            }
            else
            {
                if (transform.position == PointB.position)
                {
                    Target = 1;
                    Move = false;
                    Espera = 0;
                }
            }
           
                
        }
        else if (Target == 3 && Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointC.position, currentSpeed * Time.deltaTime);
            if (transform.position == PointC.position)
            {
                Ida = false;
                Target = 2;
                Move = false;
                Espera = 0;
            }
                
        }
        if(Espera >= TiempoEspera)
        {
            Move = true;
        }
        else
        {
            Espera += Time.deltaTime;
        }
    }
    
}
