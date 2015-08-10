using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Paper : MonoBehaviour {
    public bool isSpecial;
    void GetPaper()
    {
        FindObjectOfType<Player>().paperCount++;
        if (isSpecial) FindObjectOfType<Player>().specialPaperCount++;
        string t = GameObject.FindGameObjectWithTag("Paper_Text").GetComponent<Text>().text;
        GameObject.FindGameObjectWithTag("Paper_Text").GetComponent<Text>().text = FindObjectOfType<Player>().paperCount.ToString();
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
    }

	// Use this for initialization
	void Start () {
        this.GetComponent<DragDrop>().match = FindObjectOfType<Player>().gameObject;
	}

	// Update is called once per frame
	void Update () 
    {
	    if(this.GetComponent<DragDrop>().matchAttached)
        {
            GetPaper();
        }
	}
}
