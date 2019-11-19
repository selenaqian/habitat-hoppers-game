using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1done.player1done == 1 && p2done.player2done == 1) {
            SceneManager.LoadScene("MapArea");
        }
    }
}
