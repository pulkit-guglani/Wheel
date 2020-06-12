using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    private Rigidbody2D rb;
   // public FloatingJoystick floatingJoystick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 10;    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-20f,0),ForceMode2D.Impulse);
           // transform.position -= Vector3.right * 0.20f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(20f,0),ForceMode2D.Impulse);
            //transform.position += Vector3.right * 0.20f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0,20f),ForceMode2D.Impulse);
            //transform.position += Vector3.up * 0.20f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(0,-20f),ForceMode2D.Impulse);
            //transform.position -= Vector3.up * 0.20f;
        }
        
       // Vector3 direction = Vector3.up * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;

       // rb.AddForce(direction * (Time.deltaTime * 500),ForceMode2D.Impulse);
    }
}
