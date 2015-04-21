using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Golfing : MonoBehaviour {

    public GameObject golferOrigin;
    public SpriteRenderer golfer;
    public SpriteRenderer golferSwing;
    public SpriteRenderer cursor;
    public SpriteRenderer aim;

    public Text loseText;

    private static float shotDelay = .3f;
    private float shotTimer = 0;

    public float aimSpeed = 180;
    public float angle = 0;
    public float power = 10;
    public float powerBarCycle = 2;
    private float powerBarTimer = 0;
    private bool isShooting = false;

    public bool lose = false;

    public float powerDistRatio = .03f;

    private Rigidbody2D body;
    private Vector2 aimVector = Vector2.up;

    static float aimOffset = 10;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        golferSwing.enabled = false;
        loseText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(body.velocity.magnitude);

        shotTimer -= Time.deltaTime;

        if (lose)
        {
            loseText.enabled = true;
            if (Input.GetButtonDown("Continue"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            return;
        }

        if (isShooting)
        {
            golfer.enabled = false;
            golferSwing.enabled = true;
            //power timer
            powerBarTimer += Time.deltaTime;
            if (powerBarTimer >= powerBarCycle)
                powerBarTimer -= powerBarCycle;
            //power current ratio
            float pRatio = 0;
            if (powerBarTimer > powerBarCycle / 2)
            {
                pRatio = (powerBarCycle / 2 - (powerBarTimer - powerBarCycle / 2)) / (powerBarCycle / 2);
            }
            else
            {
                pRatio = powerBarTimer / (powerBarCycle / 2);
            }
            //actual power
            float currentPower = power * pRatio;
            //cursor movement
            Vector2 cursorPos = currentPower * aimVector * powerDistRatio;
            cursor.transform.position = transform.position + new Vector3(cursorPos.x, cursorPos.y, 0);
            if (Input.GetButtonDown("Continue"))
            {
                shotTimer = shotDelay;
                body.AddForce(currentPower * aimVector);
                isShooting = false;
                AudioSource sound = GetComponent<AudioSource>();
                sound.Play();
            }
        }
        else if (body.velocity == Vector2.zero && shotTimer <= 0)
        {
            golfer.enabled = true;
            golferSwing.enabled = false;
            if (Input.GetButtonDown("Continue"))
            {
                isShooting = true;
                powerBarTimer = 0;
            }
            angle -= Input.GetAxis("Horizontal") * aimSpeed * Time.deltaTime;
            angle = angle % 360;
            aimVector = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            aim.transform.position = new Vector3(
                transform.position.x + aimVector.x * aimOffset,
                transform.position.y + aimVector.y * aimOffset,
                aim.transform.position.z);
            cursor.transform.position = new Vector3(
                transform.position.x + aimVector.x * aimOffset * 2,
                transform.position.y + aimVector.y * aimOffset * 2,
                cursor.transform.position.z);
            golferOrigin.transform.rotation = Quaternion.Euler(0, 0, angle);
            aim.enabled = true;
            golferOrigin.transform.position = transform.position;
        }
        else
        {
            golfer.enabled = true;
            golferSwing.enabled = false;
            aim.enabled = false;
        }
	}
}
