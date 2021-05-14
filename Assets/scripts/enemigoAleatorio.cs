using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoAleatorio : MonoBehaviour
{
    public float velocityX = -5;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * velocityX;
    }
    

}
