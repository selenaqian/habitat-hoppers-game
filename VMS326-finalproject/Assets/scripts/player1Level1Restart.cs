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
        Time.timeScale = 1.0f;
        player1movement.p1dead = 0;
        player2movement.p2dead = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitClicked()
    {
        Time.timeScale = 1.0f;
        player1movement.p1dead = 0;
        player2movement.p2dead = 0;
        SceneManager.LoadScene("MapArea");
    }
}
