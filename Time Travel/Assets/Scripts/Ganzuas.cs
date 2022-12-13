using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ganzuas : MonoBehaviour
{
    public GameObject KeyInteraction;
    public KeyCode Interactuar;
    private bool canPick;
    public GameObject Player;
    
    [SerializeField] private Text Ganzuastext;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            canPick = true;
            KeyInteraction.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            canPick = false;
            KeyInteraction.SetActive(false);
        }
    }
    void Update()
    {
        if(canPick)
        {
            if (Input.GetKeyDown(Interactuar))
            {
                Player.GetComponent<Player>().Ganzuas += 1;
                gameObject.SetActive(false);
                KeyInteraction.SetActive(false);
                Ganzuastext.text = "Ganzuas: "+ Player.GetComponent<Player>().Ganzuas;
            }
        }
    }

}
