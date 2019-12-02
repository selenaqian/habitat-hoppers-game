using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapP1Movement : MonoBehaviour
{
    public float rotationSpeed=50.0f;
	public float translationSpeed=20.0f;
    //public float xforce = 30.0f;
    //public float yforce = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(backtomap.xStart, 0.5f, backtomap.zStart);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 travelDir = transform.TransformDirection(Vector3.forward); //get in world coordinates
        travelDir.y = 0.0f; //prevent user from changing altitude above plane
        travelDir.Normalize();
      
        if(Input.GetKey("a"))
        {
            transform.Rotate(0f, -1.0f * rotationSpeed * Time.deltaTime, 0f,Space.World);
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(-xforce, 0, 0), ForceMode.Force);
        }
        
        if(Input.GetKey("d"))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(xforce, 0, 0), ForceMode.Force);
        }
        
        if(Input.GetKey("w"))
        {
            transform.Translate(travelDir * Time.deltaTime * translationSpeed, Space.World);
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, yforce), ForceMode.Force);
        }
        
        if(Input.GetKey("s"))
        {
            transform.Translate(-travelDir * Time.deltaTime * translationSpeed, Space.World);
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -yforce), ForceMode.Force);
        }
    }
}
