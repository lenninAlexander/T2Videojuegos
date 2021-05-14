using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creadorZombies : MonoBehaviour
{
    public GameObject[] zombies;
    public float tiempoMin = 2f, tiempoMax = 4f;
    void Start()
    {
        Generar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Generar()

    {
        Instantiate(zombies[Random.Range(0, zombies.Length)], transform.position, Quaternion.identity);
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
    }
}
