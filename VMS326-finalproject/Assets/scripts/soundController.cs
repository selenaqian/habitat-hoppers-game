using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soundController : MonoBehaviour
{
    AudioSource mainaudio;
    // Start is called before the first frame update
    void Start()
    {
        mainaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "Winner")
        {
            if(!mainaudio.isPlaying)
            {
                mainaudio.Play();
            }
        }
        else if(mainaudio.isPlaying)
        {
            mainaudio.Stop();
        }
    }
}
