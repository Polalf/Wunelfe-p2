using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public bool InPresent;
    public Camera cam1;
    public Camera cam2;
    public KeyCode ChangeCam;
    private bool itsPresent;
    

   

    private void Update()
    {
        if(Input.GetKeyDown(ChangeCam))
        {
            Switch(itsPresent);
            itsPresent = !itsPresent;
        }
    }
    private void Switch(bool present)
    { 
        if(present = InPresent)
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }
        else
        {
            cam2.enabled = true;
            cam1.enabled = false;
        }
    }
}
