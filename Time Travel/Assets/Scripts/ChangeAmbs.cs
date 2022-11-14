using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAmbs : MonoBehaviour
{
    public bool Present;
    private bool itsPresent;
    public KeyCode changeKey;
    public GameObject otherCamera;

    void Update()
    {
        if(Input.GetKeyDown(changeKey))
        {
            gameObject.SetActive(false);
            otherCamera.SetActive(true);


        }
    }
}
