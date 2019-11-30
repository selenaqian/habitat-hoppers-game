using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    //set as the two players
    public Transform player1;
    public Transform player2;
    
    //sets when to move camera
    public float xbound = 3.0f;
    public float ybound = 5.0f;
    
    //position and speed for lerp
    Vector3 moveTo;
    public float speed = 0.2f;
    
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
        
        float dx1 = player1.position.x - transform.position.x; //x-distance between camera and player1
        float dx2 = player2.position.x - transform.position.x; //x-distance between camera and player2
        
        float dy1 = player1.position.y - transform.position.y; //y-distance between camera and player1
        float dy2 = player2.position.y - transform.position.y; //y-distance between camera and player2
        
        if (dx1 > xbound)
        {
            delta1.x = dx1 - xbound;
        }
        //if x-distance too large on the right - dx > xbound - then move camera
        //check if other player is still on screen - if not, drag them over also
        
        //if y-distsance too large going up - dy > ybound - then move camera
        //check if other player still on screen - if not, they die
        
        //update moveTo position
        moveTo = transform.position + delta1;
        //lerp
        transform.position = Vector3.Lerp(transform.position, moveTo, speed);
    }
}
