using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1movement : MonoBehaviour
{
    public static int p1dead;
    // Start is called before the first frame update
    void Start()
    {
        p1dead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Force);
        }
        if(Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0), ForceMode2D.Force);
        }
        if (Input.GetKeyDown("w"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
        
        //check for death condition
        if(transform.position.y < -10) {
            p1dead = 1;
        }
      
    }
}
