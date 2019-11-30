using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    //Goal 1: move camera to be ahead of the player when one of the players gets about 3/4 of the way to the right of the screen
    
    //set as the two players
    public Transform player1;
    public Transform player2;
    
    //sets when to move camera
    public float xboundright = 4.0f;
    public float xboundleft = 6.0f;
    public float yboundtop = 0.5f;
    public float yboundbottom = 1.5f;

    //sets how far to move camera --> lower = move further
    public float xmotion = 1.0f;
    public float ymotion = 0.5f;
    
    //record if moving or not and which player is in control of that at the moment
    private int p1x=0;
    private int p2x=0;
    private int p1y=0;
    private int p2y=0;
    
    //position and speed for lerp
    Vector3 moveTo;
    public float speed = 0.015f;
    
    Vector3 temp = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void LateUpdate()
    {
        Vector3 delta1 = Vector3.zero;
        
        float dx1 = player1.position.x - transform.position.x; //x-distance between player1 and camera
        float dx2 = player2.position.x - transform.position.x; //x-distance between player2 and camera
        
        float dy1 = player1.position.y - transform.position.y; //y-distance between player1 and camera
        float dy2 = player2.position.y - transform.position.y; //y-distance between player2 and camera
        
        //if x-distance too large on the right - dx > xbound - then move camera
        if (dx1 > xboundright || dx2 > xboundright)
        {
            //Debug.Log(dx1);
            if (dx1 > xboundright)
            {
                temp.x = dx1 - xmotion;
                p1x = 1;
            }
            else if (dx2 > xboundright)
            {
                temp.x = dx2 - xmotion;
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
            //Debug.Log("stopping");
            temp.x = 0;
            p1x = 0;
        }
        else if (dx2 < -xboundleft && p2x == 1)
        {
            temp.x = 0;
            p2x = 0;
        }
        
        //if y-distance too large going up - dy > ybound - then zoom out? if other one is too low, move if both going up
        if (dy1 > yboundtop || dy2 > yboundtop)
        {
            //Debug.Log(dy1);
            if (dy1 > yboundtop)
            {
                temp.y = dy1 - ymotion;
                p1y = 1;
            }
            else if (dy2 > yboundtop)
            {
                temp.y = dy2 - ymotion;
                p2y = 1;
            }
        }
        if (dy1 < -yboundtop && p1y == 1)
        {
            temp.y = 0;
            p1y = 0;
        }
        else if (dy2 < -yboundtop && p2y == 1)
        {
            temp.y = 0;
            p2y = 0;
        }
        /*else if (dy1 < -yboundtop)
        {
            //Debug.Log(dy1);
            temp.y = dy1 + ymotion;
        }*/
        //if camera already in place where can see a little ahead in map, reset temp to 0
        /*if (dy1 < -yboundbottom)
        {
            //Debug.Log("stopping");
            temp.y = 0;
        }*/
        
        //update moveTo position
        moveTo = transform.position + temp;
        //lerp
        transform.position = Vector3.Lerp(transform.position, moveTo, speed);
        
        //check if players are still on screen - if not, drag them over also
        if (dx2 < - (float)Screen.width/(float)Screen.height * Camera.main.orthographicSize)
        {
            //Debug.Log("camera pos: " + transform.position.x + " player2 pos: " + player2.position.x + " width: " + Screen.width/Screen.height * Camera.main.orthographicSize);
            //Debug.Log("player2 offscreen left");
            player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
        }
        
        if (dx1 < - (float)Screen.width/(float)Screen.height * Camera.main.orthographicSize)
        {
            player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
        }
    }
}
