using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> oraciones;
    
    void Start()
    {
        
        oraciones = new Queue<string>();
    }

    public void end()
    {
        oraciones = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Empezar conversacion con" + dialogue.name);

        oraciones.Clear();

        foreach(string oracion in dialogue.oraciones)
        {
            oraciones.Enqueue(oracion);
        }

        //DisplaySigOracion();
    }
    public bool DisplaySigOracion()
    {
        if(oraciones.Count == 0)
        {
            FinDialogo();
            
            return true;
        }
        string oracion = oraciones.Dequeue();
        Debug.Log(oracion);
        return false;
       
    }
    void FinDialogo()
    {
        Debug.Log("fin conversacion");
        
    }

}
