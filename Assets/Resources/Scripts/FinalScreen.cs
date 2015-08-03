using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScreen : MonoBehaviour {
    public Text paper;
    public Text EPaper;
    public Text stars;
	// Use this for initialization
	void Start () {
	// model ---> paper : Epaper :stars
       string[] e =  PlayerPrefs.GetString("score").Split(':');
       paper.text = e[0];
       EPaper.text = e[1];
       stars.text = e[2];

	}

	// Update is called once per frame
	void Update () {
	
	}
}
