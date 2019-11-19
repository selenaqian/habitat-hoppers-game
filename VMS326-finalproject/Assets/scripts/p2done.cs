using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2done : MonoBehaviour
{
    public static int player2done;
    // Start is called before the first frame update
    void Start()
    {
        player2done = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "player2") {
            player2done = 1;
        }
    }
}
