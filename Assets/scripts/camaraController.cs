using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour
{
    public GameObject ninja;
    // private Transform _transform;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var x = ninja.transform.position.x + 15;
        // var y = player.transform.position.y + 5;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
