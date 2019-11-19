using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject text;
    public GameObject p1;
    public GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        p1.SetActive(true);
        p2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(player1movement.p1dead == 1 || player2movement.p2dead == 1) {
            text.SetActive(true);
            p1.SetActive(false);
            p2.SetActive(false);
        }
    }
}
