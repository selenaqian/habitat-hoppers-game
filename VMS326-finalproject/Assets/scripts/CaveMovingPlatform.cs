using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMovingPlatform : MonoBehaviour
{
    public AnimationCurve myCurve;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
