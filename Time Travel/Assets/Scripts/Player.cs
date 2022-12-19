using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //public Animator playerAnimator;

    [Header("Move")]
    public float speed = 5f;
    public float currentSpeed;
    public bool canMove = true;
    //public bool InConversation;
    //private Vector3 playerVelocity;
    //public CharacterController controller;



    [Header("Life")]
    public int maxLife;
    public int currentLife;
    public GameObject gameOver;
    ////public HealthBar healthBar;

    [Header("Items")]
    public int Ganzuas;

    [Header("Dialogue")]
    public Dialogue dialogue;


    private void Start()
    {
        
        currentSpeed = speed;
        //Ganzuas = 0;


        currentLife = maxLife;
        //healthBar.SetMaxHealth(maxLife);
        //canAttack = true;
    }

    void Update()
    {
        //MOVE
        if (canMove)
        {
            //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //controller.Move(move * Time.deltaTime * currentSpeed);

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(x, 0, z).normalized * currentSpeed * Time.deltaTime;

            //Rigibody es recomendable usar SOLO cuando quieres aplicar mecanicas con FISICAS, si no es el caso NO USARLO PARA EL MOVIMIENTO

            //if (Input.GetAxis("Horizontal") < -0.001f || Input.GetAxis("Horizontal") > 0.001f)
            //{
            //    rb.velocity += transform.right * Input.GetAxis("Horizontal") * currentSpeed;
            //   // transform.rotation = Quaternion.Euler(0, 180, 0);

            //}
            //if (Input.GetAxis("Vertical")<- 0.001f || Input.GetAxis("Vertical") >0.001)
            //{
            //    rb.velocity += transform.forward * Input.GetAxis("Vertical") * currentSpeed;
            //    //transform.rotation = Quaternion.Euler(0, 0, 0);
            //}
        }
        //if (InConversation)
        //{
        //    currentSpeed = 0;
        //}
        //else
        //{
        //    currentSpeed = speed;
        //}

        //LIFE
        if (currentLife <= 0)
        {
            gameObject.SetActive(true);

        }
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }



    }
    public void Stop(bool finished)
    {
        if (finished)
        {
            currentSpeed = speed;
        }
        else
        {
            currentSpeed = 0;
        }

    }



    //public void PlayerTakeDamage(int enemyDamage)
    //{
    //    currentLife -= enemyDamage;
    //    healthBar.SetHealth(currentLife);

    //    if (currentLife <= 0)
    //    {
    //        //GameOver
    //        Debug.Log("GameOver");

    //    }
    //}





}
 