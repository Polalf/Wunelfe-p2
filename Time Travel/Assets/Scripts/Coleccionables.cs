using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coleccionables : MonoBehaviour
{
    public Image ImagenNota;
    public GameObject InteractKey;
    public KeyCode Interactuar;
    private bool CanPick;

    void Update()
    {
        if(CanPick)
        {
            if(Input.GetKeyDown(Interactuar))
            {
                gameObject.SetActive(false);
                ImagenNota.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            InteractKey.SetActive(true);
            CanPick = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            InteractKey.SetActive(false);
            CanPick = false;

        }
    }
}
