using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float velocityX = 10f;
    private Rigidbody2D rb;
    private ninjaplayer playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<ninjaplayer>();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * velocityX;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            playerController.IncrementerPuntajeEn10();
        }
    }
   

}
   
