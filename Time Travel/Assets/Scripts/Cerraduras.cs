using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen = UnityEngine.Screen;

public class Cerraduras : MonoBehaviour
{
    public GameObject Marc1, Marc2, Marc3;
    public GameObject player;
    int current = 0;
    public float rotate;
    public KeyCode activar;
    private int correctas;
    public GameObject Body;
    
    public GameObject Puerta;
    


    bool inside = false;

    private void Start()
    {

        
        player = GameObject.FindGameObjectWithTag("Player");
        correctas = 0;
        Marc1.SetActive(true);
        Marc2.SetActive(false);
        Marc3.SetActive(false);
    }
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");


        if (inside)
        {
            if (Input.GetKeyDown(activar))
            {
                correctas++;
                if (current == 0)
                {
                    Marc1.SetActive(false);
                    Marc2.SetActive(true);
                    current += 1;
                }

                else if (current == 1)
                {
                    Marc2.SetActive(false);
                    Marc3.SetActive(true);
                    current += 2;
                }

                else if (current == 2)
                {
                    Marc3.SetActive(false);
                }

            }


        }
        else if (!inside)
        {
            if (Input.GetKeyDown(activar))
            {
                player.GetComponent<Player>().Ganzuas -= 1;
            }
        }
        if(player.GetComponent<Player>().Ganzuas<= 0)
        {
            Body.SetActive(false);

        }

        if (moveX == -1)
        {
            transform.Rotate(0, 0, rotate * Time.deltaTime);

        }
        if (moveX == 1)
        {
            transform.Rotate(0, 0, -rotate * Time.deltaTime);
        }
        if (correctas >= 3)
        {
            Debug.Log("listo");
            Puerta.GetComponent<Puertas>().abierta = true;
            
            player.GetComponent<Player>().Stop(true);
            Body.SetActive(false);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    }
}
