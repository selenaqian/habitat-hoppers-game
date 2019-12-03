using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1Level1Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void P1L1Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        player1movement.p1dead = 0;
        player2movement.p2dead = 0;
    }

    public void QuitClicked()
    {
        SceneManager.LoadScene("MapArea");
        Time.timeScale = 1.0f;
        player1movement.p1dead = 0;
        player2movement.p2dead = 0;
    }
}
