using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1done : MonoBehaviour
{
    public static int player1done;
    // Start is called before the first frame update
    void Start()
    {
        player1done = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "player1") {
            player1done = 1;
        }
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "player1") {
            player1done = 0;
        }
    }
}
