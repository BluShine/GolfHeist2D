using UnityEngine;
using System.Collections;

public class Slope : MonoBehaviour {

    public float direction = 0;
    public float power = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        Vector2 dir = new Vector2(Mathf.Cos(direction * Mathf.Deg2Rad), Mathf.Sin(direction * Mathf.Deg2Rad));
        GameObject obj = coll.gameObject;
        if (obj.tag == "Player")
        {
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            body.AddForce(body.velocity.magnitude * dir * power);
            Debug.DrawLine(body.transform.position, 
                body.transform.position + new Vector3(dir.x, dir.y, body.transform.position.z) * 10, 
                Color.red);
        }
    }
}
