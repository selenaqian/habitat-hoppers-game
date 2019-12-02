using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBehindP1 : MonoBehaviour
{
    public GameObject player1;
    Queue<Vector3> p1path = new Queue<Vector3>();
    Vector3 temp = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1path.Enqueue(player1.transform.position);
        if (p1path.Count > 60 && Vector3.Distance(transform.position, player1.transform.position) > 5.0f)
        {
            temp = p1path.Dequeue();
        }
        transform.position = Vector3.Lerp(transform.position, temp, 0.1f);
    }
}
