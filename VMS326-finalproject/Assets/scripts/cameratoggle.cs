using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratoggle : MonoBehaviour
{
    public Camera main;
    public Camera overhead;
    private Rect small;
    private Rect full;
    // Start is called before the first frame update
    void Start()
    {
        small = new Rect(0.8f, 0.0f, 1.0f, 0.2f);
        full = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        main.rect = full;
        overhead.rect = small;
        main.depth = -1;
        overhead.depth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y")) {
            if(main.rect == full){
                main.rect = small;
                overhead.rect = full;
                main.depth = 0;
                overhead.depth = -1;
            }
            else {
                main.rect = full;
                overhead.rect = small;
                main.depth = -1;
                overhead.depth = 0;
            }
        }
    }
}
