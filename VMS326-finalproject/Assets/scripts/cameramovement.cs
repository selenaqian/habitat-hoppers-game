using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    
    public float xbound = 5.0f;
    public float ybound = 5.0f;
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
    }
}
