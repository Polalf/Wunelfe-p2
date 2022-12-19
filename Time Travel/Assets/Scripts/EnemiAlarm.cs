using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAlarm : MonoBehaviour
{
    public GameObject Enemy;

  

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.transform.tag == "Player"))
        {
            Enemy.GetComponent<Enemies>().enabled = true;
            Enemy.GetComponent<NPC>().enabled = false;
            Debug.Log("intruso detectado");

        }

    }
}
