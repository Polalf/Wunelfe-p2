using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    [Header("Interaccion")]
    public GameObject Player;
    public GameObject keyCheck;

    public GameObject KeyInteraction;
    public KeyCode Interactuar;
    public bool abierta = false;
    public Transform pointB;

    public Dialogue dialogue;
    public GameObject dialogueManager;

    public bool canEnter = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if (Input.GetKeyDown(Interactuar) && abierta && canEnter)
        {
            Debug.Log("oli");
            Entrar();

        }
        else if (Input.GetKeyDown(Interactuar) && !abierta && canEnter)
        {
            if (Player.GetComponent<Player>().Ganzuas <= 0)
            {
                Debug.Log("consigue Ganzuas");
                //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                dialogueManager.GetComponent<DialogueManager>().DisplaySigOracion();
                Player.GetComponent<Player>().Stop(true);
            }
            else if (Player.GetComponent<Player>().Ganzuas > 0)
            {
                keyCheck.SetActive(true);
                Debug.Log("cerradura");
                Player.GetComponent<Player>().Stop(false);

            }

        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if(collision.transform.tag == "Player")
        {
            canEnter = true;
            KeyInteraction.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            


        }
           
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            canEnter = false;
            FindObjectOfType<DialogueManager>().end();
            KeyInteraction.SetActive(false);

        }
            
        

        //if (collision.CompareTag("Player"))
        //{
        //    keyStart.SetActive(false);
        //    if (Input.GetKeyDown(Interactuar))
        //    {
        //        keyCheck.SetActive(true);
        //        Debug.Log("saliste");
        //    }
        //}
    }
    public void Entrar()
    {
        Player.transform.position = pointB.position;
        canEnter = false;
    }
}
