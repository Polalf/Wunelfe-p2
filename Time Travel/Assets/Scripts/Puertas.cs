using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject keyCheck;

    public GameObject keyStart;
    public KeyCode Start;

    private void OnTriggerStay(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            keyStart.SetActive(true);
            if (Input.GetKeyDown(Start))
            {
                keyCheck.SetActive(true);
                Debug.Log("cerradura");
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            keyStart.SetActive(false);
            if (Input.GetKeyDown(Start))
            {
                keyCheck.SetActive(true);
                Debug.Log("saliste");
            }
        }
    }
}
