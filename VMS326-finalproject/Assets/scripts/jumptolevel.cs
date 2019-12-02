using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumptolevel : MonoBehaviour
{
    Renderer rend;
    public string jumpto;
    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "player1") {
            rend.material.color = Color.black;
            SceneManager.LoadScene(jumpto);
        }
    }
}
