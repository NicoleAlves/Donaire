using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    int timer;

	// Use this for initialization
	void Start () {
        timer = 200;
	}

	// Update is called once per frame
	void Update () {
        timer--;
        if (timer < 0)
        {
                Application.LoadLevel(0);
        }
	}
}
