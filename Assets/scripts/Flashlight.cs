using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    public Golfing golf;

    public bool on = true;
    private SpriteRenderer render;

	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            render.enabled = true;
        }
        else
        {
            render.enabled = false;
        }

	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (on && coll.gameObject.tag == "Player")
        {
            golf = GameObject.Find("ball").GetComponent<Golfing>();
            golf.lose = true;
        }
    }
}
