using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2movement : MonoBehaviour
{
    public static int p2dead;
    private int numjumps = 0;
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
        if (Input.GetKeyDown("up") && numjumps<2)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            numjumps++;
        }
        
        //check for death condition
        /*if(transform.position.y < -15) {
            p2dead = 1;
        }*/
        
        //off-screen death condition
        float dx2 = transform.position.x - Camera.main.transform.position.x;
        if (dx2 < - (float)Screen.width/(float)Screen.height * Camera.main.orthographicSize - 0.1f)
        {
            p2dead = 1;
        }
      
    }
    
    //falling death condition
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("p2 hit water");
        p2dead = 1;
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        numjumps=0;
    }
}
