using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAmbs : MonoBehaviour
{
   
    public KeyCode changeKey;
    public GameObject otherCamera;
    public GameObject CdBar;
    public GameObject Past,Present;
    public bool InPast;
    public bool canChange;

    private void Start()
    {
        // Past = GameObject.FindGameObjectWithTag("Past");
        // Present = GameObject.FindGameObjectWithTag("Present");
    }
    void Update()
    {
       //
        {
            if (!InPast) // Estoy en el presente
            {
                Present.SetActive(true);
                Past.SetActive(false);
                

            }
            else
            {
                Present.SetActive(false);
                Past.SetActive(true);
                


            }
            if (Input.GetKeyDown(changeKey))
            {
                gameObject.SetActive(false);
                otherCamera.SetActive(true);
                // InPast = !InPast;
            }
        }
        
        
        
        

    }
}
