using UnityEngine;
using System.Collections.Generic;

public class Interlude : MonoBehaviour {

    public float revealTime = 1;
    public List<RectTransform> texts;
    public string nextScene;
    private int currentRender = 0;
    private float rTimer = 0;

	// Use this for initialization
	void Start () {
        foreach (RectTransform t in texts)
        {
            t.localScale = Vector3.zero;
            
        }
        if (texts.Count >= 1)
            texts[0].localScale = new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        rTimer += Time.deltaTime;
        if (rTimer >= revealTime)
        {
            currentRender++;
            rTimer -= revealTime;
            if (currentRender < texts.Count)
                texts[currentRender].localScale = new Vector3(1, 1, 1);
        }

        if (currentRender >= texts.Count && Input.GetButtonDown("Continue"))
            Application.LoadLevel(nextScene);
	}
}
