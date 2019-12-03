using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowBehind : MonoBehaviour
{
    public float turnSpeed = 4.0f;
      public Transform player;
  
      private Vector3 offset;
  
      void Start () {
          offset = new Vector3(player.position.x + 7.0f, player.position.y + 8.0f, player.position.z);
      }
  
      void LateUpdate()
      {
          offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
          transform.position = player.position + offset; 
          transform.LookAt(player.position);
      }
    /*public GameObject player1;
    //Queue<Transform> p1path = new Queue<Transform>();
    Transform temp;
    Vector3 tempVector = new Vector3(50.1f, 2.0f, -8.1f);
    Vector3 tempdir = Vector3.zero;
    float rotationx = 0.0f;
    float rotationy = 0.0f;
    float rotationz = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationx = 0.0f;
        rotationy = 0.0f;
        rotationz = 0.0f;
        //p1path.Enqueue(player1.transform);
        if (Vector3.Distance(transform.position, player1.transform.position) > 30.0f || !(player1.GetComponent<Renderer>().isVisible))
        {
            //temp = p1path.Dequeue();
            temp = player1.transform;
            tempdir = temp.transform.TransformDirection(Vector3.forward); // find direction p1 was traveling in - use to set up offset
            tempdir.Normalize();
            tempVector.x = temp.position.x - 10.0f*tempdir.x;
            tempVector.z = temp.position.z - 10.0f*tempdir.z;
            rotationx = temp.rotation.eulerAngles.x;
            rotationy = temp.rotation.eulerAngles.y;
            rotationz = temp.rotation.eulerAngles.z;
        }
        transform.position = Vector3.Lerp(transform.position, tempVector, 0.1f);
        transform.Rotate(rotationx, rotationy, rotationz, Space.World);
    }*/
}
