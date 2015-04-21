using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Diamond : MonoBehaviour {

    public string nextScene;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerStay2D(Collider2D coll)
    {
        GameObject obj = coll.gameObject;
        if (obj.tag == "Player")
        {
            Application.LoadLevel(nextScene);
        }
	}
}
