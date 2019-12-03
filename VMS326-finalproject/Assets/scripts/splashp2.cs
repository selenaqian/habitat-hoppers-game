using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashp2 : MonoBehaviour
{
    AudioSource p2SplashDeathAudio;
    private bool audioplayed;
    // Start is called before the first frame update
    void Start()
    {
        p2SplashDeathAudio = GetComponent<AudioSource>();
        audioplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player2movement.p2dead == 1 && !p2SplashDeathAudio.isPlaying && !audioplayed)
        {
            p2SplashDeathAudio.Play();
            audioplayed = true;
        }
    }
}
