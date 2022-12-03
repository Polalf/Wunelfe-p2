using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

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

        nameText.text = dialogue.name;
        oraciones.Clear();

        foreach (string oracion in dialogue.oraciones)
        {
            oraciones.Enqueue(oracion);
        }

        //DisplaySigOracion();
    }
    public bool DisplaySigOracion()
    {
        if (oraciones.Count == 0)
        {
            FinDialogo();

            return true;
        }
        animator.SetBool("Open", true);
        string oracion = oraciones.Dequeue();
        Debug.Log(oracion);
        StopAllCoroutines();
        StartCoroutine(EscribirOracion(oracion));
        return false;
       
    }
    IEnumerator EscribirOracion(string oracion)
    {
        dialogueText.text = "";
        foreach(char letter in oracion.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void FinDialogo()
    {
        Debug.Log("fin conversacion");
        animator.SetBool("Open",false);
    }

}
