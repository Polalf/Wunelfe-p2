using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Move")]


    [Header("Interaccion")]
    public KeyCode Interactuar;
    public bool canTalk;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
             canTalk = true;
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            canTalk = false;
        }
        
    }
    void Update()
    {
        if (canTalk)
        {
            if (Input.GetKeyDown(Interactuar))
            {
                Debug.Log("Contacto");
            }
        }
    }
}
