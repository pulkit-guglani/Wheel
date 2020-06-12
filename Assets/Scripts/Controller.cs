using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.mass = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-20f,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(20,0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0,100));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0,-20));
        }
    }
    
    
}
