using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject Player;
    public GameObject keyCheck;

    public GameObject keyStart;
    public KeyCode StartQuest;
    public bool abierta = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay(Collider collision)
    {

        if(collision.CompareTag("Player"))
        {
            keyStart.SetActive(true);
            if (Input.GetKeyDown(StartQuest) && abierta)
            {
                Debug.Log("entra");
            }
            else if(abierta == false && Input.GetKeyDown(StartQuest))
            { 
                keyCheck.SetActive(true);
                Debug.Log("cerradura");

            }
            else if(Player.GetComponent<Player>().Ganzuas == 0 && Input.GetKeyDown(StartQuest))
            {
                
                Debug.Log("consigue Ganzuas");
            
                
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            keyStart.SetActive(false);
            if (Input.GetKeyDown(StartQuest))
            {
                keyCheck.SetActive(true);
                Debug.Log("saliste");
            }
        }
    }
}
