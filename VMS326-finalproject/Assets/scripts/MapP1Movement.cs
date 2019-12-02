using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapP1Movement : MonoBehaviour
{
    public float xforce = 30.0f;
    public float yforce = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(-xforce, 0, 0), ForceMode.Force);
        }
        
        if(Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(xforce, 0, 0), ForceMode.Force);
        }
        
        if(Input.GetKey("w"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, yforce), ForceMode.Force);
        }
        
        if(Input.GetKey("s"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -yforce), ForceMode.Force);
        }
    }
}
