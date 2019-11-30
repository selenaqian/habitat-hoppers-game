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
    public float xboundright = 2.0f;
    public float ybound = 0.05f;
    public float xboundleft = 3.0f;
    
    //sets how far to move camera --> lower = move further
    public float xmotion = 1.0f;
    
    //position and speed for lerp
    Vector3 moveTo;
    public float speed = 0.2f;
    
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
        if (dx1 > xboundright)
        {
            //Debug.Log(dx1);
            temp.x = dx1 - xmotion;
        }
        //if camera already in place where can see a little ahead in map, reset temp to 0
        if (dx1 < -xboundleft)
        {
            //Debug.Log("stopping");
            temp.x = 0;
        }
        //check if other player is still on screen - if not, drag them over also
        
        //if y-distance too large going up - dy > ybound - then zoom out if other one is too low, move if both going up
        
        //update moveTo position
        moveTo = transform.position + temp;
        //lerp
        transform.position = Vector3.Lerp(transform.position, moveTo, speed);
    }
}
