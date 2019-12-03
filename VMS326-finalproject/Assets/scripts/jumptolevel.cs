using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumptolevel : MonoBehaviour
{
    Renderer rend;
    public string jumpto;
    public int levelnum;
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
        if(levelnum == 1 && !backtomap.level1complete)
        {
            if (other.gameObject.name == "player1")
            {
                rend.material.color = Color.blue;
                SceneManager.LoadScene(jumpto);
            }
        }
        if(levelnum == 2 && backtomap.level1complete && !backtomap.level2complete)
        {
            if (other.gameObject.name == "player1")
            {
                rend.material.color = Color.blue;
                SceneManager.LoadScene(jumpto);
            }
        }
        if (levelnum == 3 && backtomap.level1complete && backtomap.level2complete && !backtomap.level3complete)
        {
            if (other.gameObject.name == "player1")
            {
                rend.material.color = Color.blue;
                SceneManager.LoadScene(jumpto);
            }
        }
    }
}
