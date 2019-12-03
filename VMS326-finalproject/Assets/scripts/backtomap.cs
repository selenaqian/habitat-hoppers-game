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
    
    //for setting colors and whether particles active
    GameObject CubeL1;
    ParticleSystem unfinishedL1;
    ParticleSystem finishedL1;
    GameObject CubeL2;
    ParticleSystem unfinishedL2;
    ParticleSystem finishedL2;
    GameObject CubeL3;
    ParticleSystem unfinishedL3;
    ParticleSystem finishedL3;
    
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
                SceneManager.LoadSceneAsync("MapArea");
            }
            if (SceneManager.GetActiveScene().name == "Forest") //level 2
            {
                xStart = 331.2f;
                zStart = 170.0f;
                level2complete = true;
                SceneManager.LoadSceneAsync("MapArea");
            }
            if (SceneManager.GetActiveScene().name == "Cave") //level 3
            {
                xStart = 334.0f;
                zStart = 189.0f;
                level3complete = true;
                SceneManager.LoadScene("Winner");
            }
            p1done.player1done = 0;
            p2done.player2done = 0;
        }

        if (CubeL1 == null && SceneManager.GetActiveScene().name == "MapArea")
        {
            CubeL1 = GameObject.Find("CubeL1");
            unfinishedL1 = GameObject.Find("unfinishedL1").GetComponent<ParticleSystem>();
            finishedL1 = GameObject.Find("finishedL1").GetComponent<ParticleSystem>();
            CubeL2 = GameObject.Find("CubeL2");
            unfinishedL2 = GameObject.Find("unfinishedL2").GetComponent<ParticleSystem>();
            finishedL2 = GameObject.Find("finishedL2").GetComponent<ParticleSystem>();
            CubeL3 = GameObject.Find("CubeL3");
            unfinishedL3 = GameObject.Find("unfinishedL3").GetComponent<ParticleSystem>();
            finishedL3 = GameObject.Find("finishedL3").GetComponent<ParticleSystem>();
        }
    }
    
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "MapArea")
        {
            if (level1complete == true) //level 1 passed
            {
                if (unfinishedL1.isPlaying)
                {
                    unfinishedL1.Stop();
                }
                if (!(finishedL1.isPlaying))
                {
                    finishedL1.Play();
                }
                CubeL1.GetComponent<Renderer>().material.color = Color.green;
                CubeL2.GetComponent<Renderer>().material.color = Color.red;
                if (!(unfinishedL2.isPlaying))
                {
                    unfinishedL2.Play();
                }
            }
            if (level2complete == true) //level 2 passed
            {
                if (unfinishedL2.isPlaying)
                {
                    unfinishedL2.Stop();
                }
                if (!(finishedL2.isPlaying))
                {
                    finishedL2.Play();
                }
                CubeL2.GetComponent<Renderer>().material.color = Color.green;
                CubeL3.GetComponent<Renderer>().material.color = Color.red;
                if (!(unfinishedL3.isPlaying))
                {
                    unfinishedL3.Play();
                }
            }
            if (level3complete == true) //level 3 passed
            {
                SceneManager.LoadScene("Winner");
                /*if (unfinishedL3.isPlaying)
                {
                    unfinishedL3.Stop();
                }
                if (!(finishedL3.isPlaying))
                {
                    finishedL3.Play();
                }
                CubeL3.GetComponent<Renderer>().material.color = Color.green;*/
            }
        }
    }
}
