using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashp1 : MonoBehaviour
{
    AudioSource p1SplashDeathAudio;
    private bool audioplayed;
    // Start is called before the first frame update
    void Start()
    {
        p1SplashDeathAudio = GetComponent<AudioSource>();
        audioplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1movement.p1dead == 1 && !p1SplashDeathAudio.isPlaying && !audioplayed)
        {
            p1SplashDeathAudio.Play();
            audioplayed = true;
        }
    }
}
