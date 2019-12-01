using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameramovement : MonoBehaviour
{
    //Goal 1: move camera to be ahead of the player when one of the players gets about 3/4 of the way to the right of the screen
    
    //set as the two players
    public Transform player1;
    public Transform player2;
    
    //sets when to move camera
    public float xboundright = 4.0f;
    public float xboundleft = 2.0f;
    public float yboundtop = 1.5f;
    public float yboundbottom = 1.2f;

    //sets how far to move camera --> lower = move further
    public float xmotion = 1.0f;
    public float ymotion = 1.0f;
    
    //record if moving or not and which player is in control of that at the moment
    private int p1x=0;
    private int p2x=0;
    private int p1y=0;
    private int p2y=0;
    
    //position and speed for lerp
    Vector3 moveTo;
    public float speed = 0.015f;
    
    Vector3 temp = Vector3.zero;
    private float newCamSize = 5.0f; //use for zoom in/out lerp
    private float origCamSize = 5.0f;
    private float defaultCamSize = 5.0f;
    public float x = 1.0f;
    private float startZoomIn;
    
    //gameover condition
    private bool gameover = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Cave") //need a little more zoomed out for cave art
        {
            newCamSize = 7.0f;
            origCamSize = 7.0f;
            defaultCamSize = 7.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1movement.p1dead == 1 || player2movement.p2dead == 1)
        {
            gameover = true;
        }
    }
    
    private void LateUpdate()
    {
        origCamSize = Camera.main.orthographicSize;
        
        float dx1 = player1.position.x - transform.position.x; //x-distance between player1 and camera
        float dx2 = player2.position.x - transform.position.x; //x-distance between player2 and camera
        
        float dy1 = player1.position.y - transform.position.y; //y-distance between player1 and camera
        float dy2 = player2.position.y - transform.position.y; //y-distance between player2 and camera
        
        //if x-distance too large on the right - dx > xbound - then move camera
        if (dx1 > xboundright || dx2 > xboundright)
        {
            if (dx1 > xboundright)
            {
                Debug.Log("moving right1");
                temp.x = dx1 - xmotion;
                p1x = 1;
            }
            else if (dx2 > xboundright)
            {
                temp.x = dx2 - xmotion;
                Debug.Log("moving right2 camera x: " + Camera.main.transform.position.x + " moving: " + temp.x);
                p2x = 1;
            }
        }
        /*else if (dx1 < -xboundright)
        {
            temp.x = dx1 + xboundright;
        }*/ //need to get rid of backward motion because dragging the other player won't work
        
        //if camera already in place where can see a little ahead in map, reset temp to 0
        if (dx1 < -xboundleft && p1x == 1)
        {
            Debug.Log("stopping1");
            temp.x = 0;
            p1x = 0;
        }
        else if (dx2 < -xboundleft && p2x == 1)
        {
            temp.x = 0;
            p2x = 0;
        }
        
        //if y-distance too large going up - dy > ybound - then zoom out if other one is too low, move if both going up
        //set up so move based on midpoint of players, zoom based on individual on-screen
        float dyplayers = player1.position.y - player2.position.y; //y-distance between the players
        float ymidplayers = player2.position.y + dyplayers * 0.5f; //midpoint of the y-dist between the players
        float dyoverall = ymidplayers - transform.position.y; //difference between midpoint of y-dist between players and camera
        if (dyoverall > yboundtop)
        {
            //Debug.Log("moving up");
            temp.y = dyoverall - ymotion;
            p1y = 1;
        }
        else if (dyoverall < -yboundtop)
        {
            //Debug.Log("moving down");
            temp.y = dyoverall + ymotion;
            p1y = 1;
        }
        if (dyoverall < yboundbottom && dyoverall > -yboundbottom && p1y == 1)
        {
            temp.y = 0;
            p1y = 0;
        }
        //zooming
        if (dy1 > Camera.main.orthographicSize || dy1 < -Camera.main.orthographicSize) //if p1 off-screen
        {
            //Debug.Log("zoom out 1");
            newCamSize = Mathf.Abs(dy1) + 0.1f;
            p2y = 1;
        }
        else if (dy2 > Camera.main.orthographicSize || dy2 < -Camera.main.orthographicSize) //if p2 off-screen
        {
            //Debug.Log("zoom out 2");
            newCamSize = Mathf.Abs(dy2) + 0.1f;
            p2y = 1;
        }
        else if (dyplayers < defaultCamSize && p2y == 1 && p1y == 0) //if both players on-screen in default range
        {
            //Debug.Log("zoom in");
            newCamSize = defaultCamSize;
            p2y = 0;
            startZoomIn = Time.time;
        }
        /*if (dyplayers > Camera.main.orthographicSize) //if either player offscreen in y-direction
        {
            //compute new orthographic size
            newCamSize = dyplayers + 0.1f;
            p2y = 1;
        }
        if (dyplayers < 5.0f) //if p2 in middle of screen in y-direction
        {
            newCamSize = 5.0f;
        }*/
        
        //check gameover condition
        if (gameover)
        {
            temp = Vector3.zero;
        }
        
        //update moveTo position
        moveTo = transform.position + temp;
        
        //lerp
        transform.position = Vector3.Lerp(transform.position, moveTo, speed);
        //update camera size
        if ((Time.time - startZoomIn)*0.3f < 1.0f)
        {
            Camera.main.orthographicSize = Mathf.Lerp(origCamSize, newCamSize, (Time.time - startZoomIn)*0.3f);
        }
        else
        {
            Camera.main.orthographicSize = Mathf.Lerp(origCamSize, newCamSize, x);
        }
        
        //check if players are still on screen - if not, drag them over also
        if (dx2 < - (float)Screen.width/(float)Screen.height * Camera.main.orthographicSize)
        {
            //Debug.Log("camera pos: " + transform.position.x + " player2 pos: " + player2.position.x + " width: " + Screen.width/Screen.height * Camera.main.orthographicSize);
            //Debug.Log("player2 offscreen left");
            player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
        
        if (dx1 < - (float)Screen.width/(float)Screen.height * Camera.main.orthographicSize)
        {
            player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
    }
}
