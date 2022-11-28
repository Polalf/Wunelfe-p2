using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Move")]


    [Header("Interaccion")]
    public KeyCode Interactuar;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            if(Input.GetKeyDown(Interactuar))
            {
                Debug.Log("Contacto");
            }
            
        }
    }
    void Update()
    {
        
    }
}
