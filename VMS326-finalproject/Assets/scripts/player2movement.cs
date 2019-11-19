using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2movement : MonoBehaviour
{
    public static int p2dead;
    // Start is called before the first frame update
    void Start()
    {
        p2dead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Force);
        }
        if(Input.GetKey("right"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0), ForceMode2D.Force);
        }
        if (Input.GetKeyDown("up"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
        
        //check for death condition
        if(transform.position.y < -10) {
            p2dead = 1;
        }
      
    }
}
