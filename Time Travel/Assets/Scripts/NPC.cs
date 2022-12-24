using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool Enemy;
    public Animator NpcAnimator;

    [Header("Move")]
    public float speed;
    public float currentSpeed;
    public Transform PointA, PointB, PointC, CurrentTarget;
    public bool Move;
    public int Target;
    public float TiempoEspera;
    public float Espera;
    private bool Ida;
    public GameObject luzAd, luzAt, luzDe, luzIz;


    [Header("Interaccion")]
    public KeyCode Interactuar;
    public bool canTalk;
    public Dialogue dialogue;
    public GameObject dialogueManager;
    public GameObject Player;
    public bool InDialogue;

    private void Start()
    {
        
        Ida = true;
        Target = 1;
        Espera = TiempoEspera;
        Move = true;
        currentSpeed = speed;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collision)
    {
        

        if (collision.transform.tag == "Player")
        {
            if(InDialogue)
            {
                collision.gameObject.GetComponent<Player>().Stop(false);
            }
                

            Debug.Log("Contacto");
             canTalk = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            InDialogue = false;
            canTalk = false;
            FindObjectOfType<DialogueManager>().end();

            
            
        }
        
    }
    void Update()
    {
        if (canTalk)
        {
            if (Input.GetKeyDown(Interactuar))
            {

                InDialogue = true;
                bool finished = dialogueManager.GetComponent<DialogueManager>().DisplaySigOracion();
                Player.GetComponent<Player>().Stop(finished);

            }
        }
        if (InDialogue)
        {
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = speed;
        }

        if (Target == 1)
        {
            CurrentTarget.position = PointA.position;
        }
        else if (Target == 2)
        {
            CurrentTarget.position = PointB.position;
        }
        else if (Target == 3)
        {
            CurrentTarget.position = PointC.position;
        }
            
        // move

        if ( Target == 1 && Move)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.position, currentSpeed * Time.deltaTime);
            if(transform.position == PointA.position)
            {
                Ida = true;
                Target = 2;
                Move = false;
                Espera = 0;

            }
        }
        else if (Target == 2 && Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.position, currentSpeed * Time.deltaTime);
            if (Ida)
            {
                if (transform.position == PointB.position)
                {
                    Target = 3;
                    Move = false;
                    Espera = 0;

                }

            }
            else
            {
                if (transform.position == PointB.position)
                {
                    Target = 1;
                    Move = false;
                    Espera = 0;
                }
            }
           
                
        }
        else if (Target == 3 && Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.position, currentSpeed * Time.deltaTime);

            if (transform.position == PointC.position)
            {
                Ida = false;
                Target = 2;
                Move = false;
                Espera = 0;
            }
                
        }
        if(Espera >= TiempoEspera)
        {
            Move = true;
        }
        else
        {
            Espera += Time.deltaTime;
        }

        Vector2 dist = new Vector2(CurrentTarget.position.x, CurrentTarget.position.z) - new Vector2(transform.position.x, transform.position.z);
        dist.Normalize();
        
        float xMove = dist.x;
        float zMove = dist.y;

        xMove = Mathf.Abs(zMove) < Mathf.Abs(xMove) ? xMove : 0;
        zMove = Mathf.Abs(zMove) > Mathf.Abs(xMove) ? zMove : 0;

        //Debug.Log(dist);

        //animator 
        if (zMove < 0)
        {
            Debug.Log("adelante");
            if(Move)
            {
                NpcAnimator.SetFloat("ZSpeed", 1);
                NpcAnimator.SetFloat("XSpeed", 0);
                if(Enemy)
                {
                luzAd.SetActive(true);
                luzAt.SetActive(false);
                luzDe.SetActive(false);
                luzIz.SetActive(false);

                }

            }
            
            

        }
        else if (zMove > 0)
        {
            if (Move)
            {
                NpcAnimator.SetFloat("ZSpeed", -1);
                NpcAnimator.SetFloat("XSpeed", 0);
                if(Enemy)
                {
                    luzAd.SetActive(false);
                    luzAt.SetActive(true);
                    luzDe.SetActive(false);
                    luzIz.SetActive(false);
                }
            }
            Debug.Log("atras");
            // mirar atras
            
            
        }
        if (xMove < 0)
        {
            if (Move)
            {
                NpcAnimator.SetFloat("XSpeed", -1);
                NpcAnimator.SetFloat("ZSpeed", 0);
                if (Enemy)
                {
                    luzAd.SetActive(false);
                    luzAt.SetActive(false);
                    luzDe.SetActive(false);
                    luzIz.SetActive(true);
                }
            }
            Debug.Log("izquierda");
            // izquierda
            
            
        }
        else if (xMove > 0)
        {
            if (Move)
            {
                NpcAnimator.SetFloat("XSpeed", 1);
                NpcAnimator.SetFloat("ZSpeed",0);
                if (Enemy)
                {
                    luzAd.SetActive(false);
                    luzAt.SetActive(false);
                    luzDe.SetActive(true);
                    luzIz.SetActive(false);


                }
            }
            Debug.Log("derecha");
            // derecha
            
           
        }
    }
   
}
