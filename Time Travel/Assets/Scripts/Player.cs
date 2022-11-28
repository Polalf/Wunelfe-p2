using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //public Animator playerAnimator;

    [Header("Move")]
    public CharacterController controller;
    public float speed = 5f;
    private Vector3 playerVelocity;
    public float jumpForce = 10f;
    private float currentSpeed;
    private bool InConversation;

    //[Header("Life")]
    //public int maxLife;
    //public int currentLife;
    //public GameObject gameOver;
    ////public HealthBar healthBar;


    [Header("Items")]
    public int Ganzuas;

    //[Header("Dialogue")]
    //public Dialogue dialogue;


    private void Start()
    {
        
        currentSpeed = speed;
        Ganzuas = 0;
        controller = gameObject.GetComponent<CharacterController>();
        //currentLife = maxLife;
        //healthBar.SetMaxHealth(maxLife);
        //canAttack = true;
    }

    void Update()
    {
        //MOVE
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * currentSpeed);
        if (Input.GetAxis("Horizontal") < -0.001f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        if (Input.GetAxis("Horizontal") > 0.001f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(InConversation)
        {
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = speed;
        }
       
        //LIFE
        //if (currentLife <= 0)
        //{
        //    gameObject.SetActive(true);

        //}
        //if(currentLife > maxLife)
        //{
        //    currentLife = maxLife;
        //}
       
      

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
 