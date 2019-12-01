using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDuringSceneSwitch : MonoBehaviour
{
    static KeepDuringSceneSwitch instanceRef;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {
        if (instanceRef==null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
