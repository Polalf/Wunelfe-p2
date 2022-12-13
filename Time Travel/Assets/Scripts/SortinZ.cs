using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortinZ : MonoBehaviour
{
    public GameObject Player;
    public bool edificios;
    public float buildingSize = 3;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Awake()
    {
        UpdateView();
    }

    private void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        UpdateView();
        if(edificios)
        {
            if (transform.position.z < Player.transform.position.z)
            {
                //Debug.Log("( "+(transform.position.x + buildingSize) + ". " + (transform.position.x - buildingSize)+ ") " + Player.transform.position.x);
                if (transform.position.x - buildingSize <= Player.transform.position.x &&
                    transform.position.x + buildingSize >= Player.transform.position.x)
                {
                    sr.color = new Color(1, 1, 1, (float)0.2);
                }
                else
                {
                    sr.color = new Color(1, 1, 1, 1);
                }

            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
            }

        }
        
    }

    private void UpdateView()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(sr != null)
        {
            sr.sortingOrder = (int)(transform.position.z * -1000);
        }
        else
        {
            SortingGroup sg = GetComponent<SortingGroup>();
            if(sg != null)
            {
                sg.sortingOrder = (int)(transform.position.z * -1000);
            }
        }
    }
}
