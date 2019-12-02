using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBehindP1 : MonoBehaviour
{
    public GameObject player1;
    Queue<Transform> p1path = new Queue<Transform>();
    Transform temp;
    Vector3 tempVector = new Vector3(0.0f, 0.5f, 0.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1path.Enqueue(player1.transform);
        if (p1path.Count > 60 && Vector3.Distance(transform.position, player1.transform.position) > 5.0f)
        {
            temp = p1path.Dequeue();
            Vector3 tempdir = temp.transform.TransformDirection(Vector3.forward); // find direction p1 was traveling in - use to set up offset
            tempdir.Normalize();
            tempVector.x = temp.position.x - 5.0f*tempdir.x;
            tempVector.z = temp.position.z - 5.0f*tempdir.z;
        }
        transform.position = Vector3.Lerp(transform.position, tempVector, 0.1f);
    }
}
