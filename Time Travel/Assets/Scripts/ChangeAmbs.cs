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
       // if(canChange)
        {
            if (!InPast) // Estoy en el presente
            {
                Present.SetActive(true);
                Past.SetActive(false);
                //CdBar.GetComponent<VIajeTiempo>().PastOrFut(false);
                //canChange = true;

            }
            else
            {
                Present.SetActive(false);
                Past.SetActive(true);
                //CdBar.GetComponent<VIajeTiempo>().PastOrFut(true);
                //CdBar.GetComponent<VIajeTiempo>().CurrentCharge = 0;
                //canChange = false;
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
