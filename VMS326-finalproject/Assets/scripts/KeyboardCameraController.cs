using UnityEngine;
using System.Collections;

public class KeyboardCameraController : MonoBehaviour {

	public float rotationSpeed=50.0f;
	public float translationSpeed=20.0f;

	// Use this for initialization
	void Start ()
	{
	
	}

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKey("left"))
      {
         transform.Rotate(0f, -1.0f * rotationSpeed * Time.deltaTime, 0f,Space.World);
      }
      if (Input.GetKey("right"))
      {
         transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
      }

      Vector3 travelDir = transform.TransformDirection(Vector3.forward); //get in world coordinates
      travelDir.y = 0.0f; //prevent user from changing altitude above plane
      travelDir.Normalize();

      if (Input.GetKey("up"))
      {
         transform.Translate(travelDir * Time.deltaTime * translationSpeed, Space.World);
      }

      if (Input.GetKey("down"))
      {
         transform.Translate(-travelDir * Time.deltaTime * translationSpeed, Space.World);
      }
   }
}
