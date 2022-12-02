using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject Player;
    public GameObject keyCheck;

    public GameObject keyStart;
    public KeyCode Interactuar;
    public bool abierta = false;
    public Transform pointB;

    public Dialogue dialogue;

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
        else if (Input.GetKeyDown(Interactuar) && !abierta)
        {
            if (Player.GetComponent<Player>().Ganzuas <= 0)
            {
                Debug.Log("consigue Ganzuas");
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            else if (Player.GetComponent<Player>().Ganzuas > 0)
            {
                keyCheck.SetActive(true);
                Debug.Log("cerradura");
                Player.GetComponent<Player>().Stop(false);

            }

        }
    }

    private void OnTriggerStay(Collider collision)
    {

        if(collision.CompareTag("Player"))
        {
            canEnter = true;
            keyStart.SetActive(true);

            //keyStart.SetActive(true);
            //if (Input.GetKeyDown(Interactuar) && abierta)
            //{
            //    Entrar();

            //}
            //else if (Input.GetKeyDown(Interactuar) && !abierta)
            //{
            //    if (Player.GetComponent<Player>().Ganzuas <= 0)
            //    {
            //        Debug.Log("consigue Ganzuas");
            //        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            //    }
            //    else if (Player.GetComponent<Player>().Ganzuas > 0)
            //    {
            //        keyCheck.SetActive(true);
            //        Debug.Log("cerradura");
            //        Player.GetComponent<Player>().Stop(false);

            //    }

            //}


        }
           
    }
    private void OnTriggerExit(Collider collision)
    {
        canEnter = false;
        if (collision.CompareTag("Player"))
        {
            keyStart.SetActive(false);
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
