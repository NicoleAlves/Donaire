using UnityEngine;
using System.Collections;

public class PaperUI : MonoBehaviour {
    public int value;
	void Start () {
       // model ---> paper : Epaper :stars
        int r = int.Parse(PlayerPrefs.GetString("score").Split(':')[1]);
        if(r < value)
        {
            gameObject.SetActive(false);
        }

	}
	public void switchAnim()
    {
        bool i = GetComponent<Animator>().GetBool("active");
        GetComponent<Animator>().SetBool("active", !i);
    }
}
