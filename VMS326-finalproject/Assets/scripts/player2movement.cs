using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2movement : MonoBehaviour
{
    public static int p2dead;
    private int numjumps = 0;
    
    private static int xforce = 5;
    private static int yforce = 5;

    AudioSource playerdeathaudio;
    private bool audioplayed;

    // Start is called before the first frame update
    void Start()
    {
        p2dead = 0;
        audioplayed = false;
        playerdeathaudio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "Cave") //need move slower
        {
            xforce = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xforce, 0), ForceMode2D.Force);
        }
        if(Input.GetKey("right"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(xforce, 0), ForceMode2D.Force);
        }
        if (Input.GetKeyDown("up") && numjumps<2)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, yforce), ForceMode2D.Impulse);
            numjumps++;
        }
        
        //check for death condition
        /*if(transform.position.y < -15) {
            p2dead = 1;
        }*/
        
        //off-screen death condition
        float dx2 = transform.position.x - Camera.main.transform.position.x;
        if (dx2 < - (float)Screen.width/(float)Screen.height * Camera.main.orthographicSize - 0.5f)
        {
            p2dead = 1;
            if (!playerdeathaudio.isPlaying && !audioplayed)
            {
                playerdeathaudio.Play();
                audioplayed = true;
            }
        }
      
    }
    
    //falling death condition
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("p2 hit water");
        if (other.gameObject.name == "death water")
        {
        p2dead = 1;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        numjumps=0;
        if(other.gameObject.name == "movingPlatform" || other.gameObject.name == "movingPlatform1" || other.gameObject.name == "movingPlatform2" || other.gameObject.name == "movingPlatform3")
        {
            transform.parent = other.transform;
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.name == "movingPlatform" || other.gameObject.name == "movingPlatform1" || other.gameObject.name == "movingPlatform2" || other.gameObject.name == "movingPlatform3")
        {
            transform.parent = null;
        }
    } 
}
