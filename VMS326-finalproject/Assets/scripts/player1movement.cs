using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1movement : MonoBehaviour
{
    public static int p1dead;
	// Start is called before the first frame update
	private int numjumps = 0;
    
    private static int xforce = 10;
    private static int yforce = 5;

    void Start()
    {
        p1dead = 0;
        if (SceneManager.GetActiveScene().name == "Cave") //need move slower
        {
            xforce = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xforce, 0), ForceMode2D.Force);
        }
        if(Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(xforce, 0), ForceMode2D.Force);
        }
        if (Input.GetKeyDown("w") && numjumps<2)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, yforce), ForceMode2D.Impulse);
			numjumps++;
        }
        
        //check for death condition
        /*if(transform.position.y < -15) {
            p1dead = 1;
        }*/
        
        //off-screen death condition
        float dx1 = transform.position.x - Camera.main.transform.position.x;
        if (dx1 < - (float)Screen.width/(float)Screen.height * Camera.main.orthographicSize - 0.5f)
        {
            p1dead = 1;
        }
      
    }
    
    //falling death condition
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("p1 hit water");
        if (other.gameObject.name == "death water")
        {
        p1dead = 1;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        numjumps=0;
    }
}