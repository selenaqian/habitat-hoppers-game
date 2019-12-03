using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomap : MonoBehaviour
{
    public static float xStart = 50.0f;
    public static float zStart = 3.5f;
    public static bool level1complete = false;
    public static bool level2complete = false;
    public static bool level3complete = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1done.player1done == 1 && p2done.player2done == 1) {
            if (SceneManager.GetActiveScene().name == "Beach") //level 1
            {
                xStart = 104.2f;
                zStart = 40.0f;
                level1complete = true;
            }
            if (SceneManager.GetActiveScene().name == "Forest") //level 2
            {
                xStart = 331.2f;
                zStart = 150.0f;
                level2complete = true;
            }
            if (SceneManager.GetActiveScene().name == "Cave") //level 3
            {
                xStart = 334.0f;
                zStart = 189.0f;
                level3complete = true;
            }
            SceneManager.LoadScene("MapArea");
        }
    }
}
