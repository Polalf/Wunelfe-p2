using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuertaInter : MonoBehaviour
{
    public GameObject Player;
    public GameObject KeyInteraction;
    public KeyCode Salir;
    public Transform Salida;
    private bool canExit;
    private bool TimeCan;
    public float TimeToExit;
    private float TimeExit;
    


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(TimeCan)
        {
            KeyInteraction.SetActive(true);
            canExit = true;
        }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        KeyInteraction.SetActive(false);
        canExit = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Salir) && canExit)
        {
            Player.transform.position = Salida.position;
            TimeCan = false;
            TimeExit = 0;
        }
        if (TimeExit >= TimeToExit)
        {
            TimeCan = true;
        }
        else
        {
            TimeExit += Time.deltaTime;
        }
       
    }
}
