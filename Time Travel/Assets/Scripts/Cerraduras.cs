using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerraduras : MonoBehaviour
{
    public GameObject Marc1, Marc2, Marc3;
    int current = 0;
    public float rotate;
    public KeyCode activar;
    private int correctas;
    public GameObject Cerradura;
    
    bool inside = false;

    private void Start()
    {
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
        if (!inside)
        {
            if(Input.GetKeyDown(activar))
            {
                GetComponent<Player>().Ganzuas -= 1;
            }
        }
      
        else if (moveX == -1)
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
            Cerradura.SetActive(false);
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
