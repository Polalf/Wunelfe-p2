using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Animator EnemyAnimator;
    public GameObject Player;
    public float speed;
    public GameObject luzAd, luzAt, luzDe, luzIz;

    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,speed * Time.deltaTime);

        Debug.Log("Atacar intruso");
        Vector2 dist = new Vector2(Player.transform.position.x,Player.transform.position.z) - new Vector2(transform.position.x, transform.position.z);
        dist.Normalize();

        float xMove = dist.x;
        float zMove = dist.y;

        xMove = Mathf.Abs(zMove) < Mathf.Abs(xMove) ? xMove : 0;
        zMove = Mathf.Abs(zMove) > Mathf.Abs(xMove) ? zMove : 0;

        if (zMove < 0)
        {
            
            EnemyAnimator.SetFloat("ZSpeed", 1);
            EnemyAnimator.SetFloat("XSpeed", 0);
            Debug.Log("adelante");
            // mirar adelante
            luzAd.SetActive(true);
            luzAt.SetActive(false);
            luzDe.SetActive(false); 
            luzIz.SetActive(false);

        }
        else if (zMove > 0)
        {
            EnemyAnimator.SetFloat("ZSpeed", -1);
            EnemyAnimator.SetFloat("XSpeed", 0);
            Debug.Log("atras");
            // mirar atras
            luzAd.SetActive(false);
            luzAt.SetActive(true);
            luzDe.SetActive(false);
            luzIz.SetActive(false);
        }
        if (xMove < 0)
        {
            EnemyAnimator.SetFloat("XSpeed",- 1);
            EnemyAnimator.SetFloat("ZSpeed", 0);
            Debug.Log("izquierda");
            // izquierda
            luzAd.SetActive(false);
            luzAt.SetActive(false);
            luzDe.SetActive(false);
            luzIz.SetActive(true);
        }
        else if (xMove > 0)
        {
            EnemyAnimator.SetFloat("XSpeed", 1);
            EnemyAnimator.SetFloat("ZSpeed", 0);
            Debug.Log("derecha");
            // derecha
            luzAd.SetActive(false);
            luzAt.SetActive(false);
            luzDe.SetActive(true);
            luzIz.SetActive(false);

        }
    }
}
