using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pausa : MonoBehaviour
{
    public KeyCode tecla = KeyCode.Escape;
    public GameObject menuPausaUI;
    public GameObject GamePlay;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(tecla))
        {
            Pause();
        }
    }
    void Pause()
    {
        GamePlay.SetActive(false);
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
