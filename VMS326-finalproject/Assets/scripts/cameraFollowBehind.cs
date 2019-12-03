using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowBehind : MonoBehaviour
{
    
    public GameObject player1;
    Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player1.transform.position;
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        transform.position = new Vector3(player1.transform.position.x + offset.x, offset.y, player1.transform.position.z + offset.z);
    }
}
