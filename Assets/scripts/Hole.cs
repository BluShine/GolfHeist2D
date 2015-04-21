using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    public string nextScene;

    public float maxVelocity = 5;
    public float funnelPower = 5;

	// Use this for initialization
	void Start () {
	
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
        GameObject obj = coll.gameObject;
        if (obj.tag == "Player")
        {
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            Vector2 holedifference = new Vector2(transform.position.x, transform.position.y) - body.position;
            holedifference.Normalize();
            body.AddForce(holedifference * funnelPower * body.velocity.magnitude);

            if (body.velocity.magnitude < maxVelocity)
            {
                Application.LoadLevel(nextScene);
            }
        }
    }
}
