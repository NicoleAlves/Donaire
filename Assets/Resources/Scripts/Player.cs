using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : Default {
    public bool isWalking = true;
    public float barPercent;
    public int paperCount = 0;
    public int specialPaperCount = 0;
    public int stars = 0;
    public float speed;
    public bool isPlaying = true;

    void OnTriggerEnter2D(Collider2D col)
    {

		if (col.gameObject.tag.Equals("EnterPuzzle")) 
		{
			col.gameObject.transform.parent.SendMessage("startPuzzle");
		}
		if (col.gameObject.tag.Equals("OutPuzzle")) 
		{
			col.gameObject.transform.parent.gameObject.SendMessage("outPuzzle");
        }

        if (col.gameObject.tag.Equals("EndPhase") && isPlaying)
        {
            isWalking = false;
            isPlaying = false;
            PlayerPrefs.SetString("score", paperCount + ":" + specialPaperCount + ":" + stars);
            GameObject.FindGameObjectWithTag("fadeObj").GetComponent<Image>().enabled = true;
            GameObject.FindGameObjectWithTag("fadeObj").GetComponent<Animator>().SetInteger("fadeType", 0);
        }

        #region Tutorial

        if (col.gameObject.layer.Equals(8) && col.gameObject.tag.Equals("EnterPuzzle") && !col.transform.parent.GetComponent<DPuzzle>().isSolved)
        {
            isWalking = false;
        }
        else if (col.gameObject.layer.Equals(8) && col.gameObject.tag.Equals("EnterPuzzle") && col.transform.parent.GetComponent<DPuzzle>().isSolved)
        {
            col.gameObject.GetComponent<Animator>().enabled = false;
        }

        #endregion 

    }

	// Use this for initializati
	
	// Update is called once per frame
	public override void Update () 
    {
        base.Update();
        starBarUpdate();
        if (isWalking)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        GetComponent<Animator>().SetBool("isWalking", false);

	}

    public void starBarUpdate()
    {
        DPuzzle[] total = FindObjectsOfType<DPuzzle>();
        float j = 0;
        for(float i = 0;i<total.Length;i++)
        {
            if (total[(int)i].isSolved) j++;
        }
        stars = (int)j;
        barPercent = (j / total.Length);
        float actual = GameObject.FindGameObjectWithTag("starBars").GetComponent<Image>().fillAmount;
        if (barPercent != GameObject.FindGameObjectWithTag("starBars").GetComponent<Image>().fillAmount)
            GameObject.FindGameObjectWithTag("starBars").GetComponent<Image>().fillAmount = barPercent;
    }


}
