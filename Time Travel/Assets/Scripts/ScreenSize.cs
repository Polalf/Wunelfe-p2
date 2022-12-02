using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using Screen = UnityEngine.Screen;

public class ScreenSize : MonoBehaviour
{
    public float ScreenWidht;
    public float ScreenHeight;
    

    void Start()
    {
       // Debug.Log("Screen Height" + Screen.height + "Screen Width" + Screen.width);
        ScreenHeight = Screen.height / 2;
        ScreenWidht = Screen.width / 2;
    }
    private void Update()
    {
        
    }


}
