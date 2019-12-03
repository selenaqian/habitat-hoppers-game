using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("gameover");
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Beach" || SceneManager.GetActiveScene().name == "Forest" || SceneManager.GetActiveScene().name == "Cave")
        {
            if(text == null)
            {
                text = GameObject.Find("gameover");
                text.SetActive(false);
            }
            if (player1movement.p1dead == 1 || player2movement.p2dead == 1)
            {
                text.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
}
