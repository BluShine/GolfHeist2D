using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

    public SpriteRenderer alive;
    public SpriteRenderer dead;
    public Flashlight light;

	// Use this for initialization
	void Start () {
        dead.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        AudioSource sound = GetComponent<AudioSource>();
        sound.Play();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            dead.enabled = true;
            alive.enabled = false;
            light.on = false;
        }
    }
}
