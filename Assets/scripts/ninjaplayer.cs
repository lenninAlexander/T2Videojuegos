using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ninjaplayer : MonoBehaviour
{
    private Rigidbody2D ninjaRB;
    private Animator animator;
    private SpriteRenderer sr;
    public Text scoreTexto;
    private int Score = 0;
    public float speed = 10;
    public float Upspeed = 15;
    private int  cont=0;
    private bool morir = false;
    public bool puedoSaltar = false;
    public GameObject rightBullet;
    public GameObject leftBullet;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ninjaRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

  
    }

    // Update is called once per frame
    void Update()
    {
        scoreTexto.text = "Puntaje" + Score;
        setIdleAnimatio();
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(!sr.flipX)
            {
                var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .5f);
                Instantiate(rightBullet, position, rightBullet.transform.rotation);
            }
            else
            {
                var position = new Vector2(transform.position.x - 2.5f, transform.position.y - .5f);
                Instantiate(leftBullet, position, leftBullet.transform.rotation);
            }
        }

        if (Input.GetKey(KeyCode.C))
        {
            setSlideAnimatio();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            setRunAnimatio();
            ninjaRB.velocity = new Vector2(speed, ninjaRB.velocity.y);
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            setRunAnimatio();
            ninjaRB.velocity = new Vector2(-speed, ninjaRB.velocity.y);
            sr.flipX = true;
        }
        Jump();
        if (morir)
        {
            setDeadAnimatio();
            SceneManager.LoadScene("Perdiste");
        }
     
        //  if(ninjaRB.velocity.y<0)
        //{
        //    setIgleAnimatio();
        //}
        
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& puedoSaltar)
        {
            ninjaRB.velocity = Vector2.up * Upspeed;
            puedoSaltar = false;
        }
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            puedoSaltar = true;
        }
        if (collision.gameObject.layer == 7)
        {
            morir = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            cont++;
            Debug.Log(cont);
            if (cont == 2)
            {
                morir = true;
            }

        }
    }
    public void IncrementerPuntajeEn10()
    {
        Score += 10;
    }

    private void setIdleAnimatio()
     {
        animator.SetInteger("estado", 0);
    }
    private void setRunAnimatio()
    {
        animator.SetInteger("estado", 1);
    }
    private void setSlideAnimatio()
    {
        animator.SetInteger("estado", 2);
    }
    private void setDeadAnimatio()
    {
        animator.SetInteger("estado", 3);
    }
    private void setIgleAnimatio()
    {
        animator.SetInteger("estado", 4);
    }
}
