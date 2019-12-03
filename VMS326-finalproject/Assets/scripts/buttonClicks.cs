using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClicks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartClick()
    {
        //Debug.Log("start click");
        SceneManager.LoadScene("Introduction");
    }
    
    public void InstructionsClick()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayClick()
    {
        SceneManager.LoadScene("MapArea");
    }

    public void MainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetAll()
    {
        backtomap.level1complete = false;
        backtomap.level2complete = false;
        backtomap.level3complete = false;
        backtomap.xStart = 50.0f;
        backtomap.zStart = 3.5f;
    }
}
