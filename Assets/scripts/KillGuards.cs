using UnityEngine;
using System.Collections.Generic;

public class KillGuards : MonoBehaviour {

    public List<Guard> guards;
    public string nextScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool allDead = true;
        foreach (Guard g in guards)
        {
            if (g.alive.enabled)
            {
                allDead = false;
            }
        }
        if (allDead)
        {
            Application.LoadLevel(nextScene);
        }
	}
}
