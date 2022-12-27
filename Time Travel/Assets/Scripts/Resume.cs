using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    public GameObject menuPausaUI;
    public GameObject GamePlay;

   public void Continuar()
    {
        Time.timeScale = 1f;
        menuPausaUI.SetActive(false);
        GamePlay.SetActive(true);
    }
    
    public void CargarEscena(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }
   
}
