using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Default {
	public GameObject lastCheckPoint;
	public GameObject current ;
	public int nextChoice = 0;
    public static int trys = 1;
    public bool isWalking = true;
    
    public float speed;

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
        if(col.gameObject.tag.Equals("WayPoint") && col.gameObject != lastCheckPoint)
        {
            if (col.gameObject.GetComponent<WayPoint>().options.Count > 0)
            {
                lastCheckPoint = current;
                current = col.gameObject.GetComponent<WayPoint>().options[nextChoice];
                nextChoice = 0;
            }
            else if(DPuzzle.actualPlayer.tag.Equals("Joao"))
            {
                DPuzzle.actualPlayer = GameObject.FindGameObjectWithTag("Maria");
                Camera.main.GetComponent<CameraFollow>().target = DPuzzle.actualPlayer.transform;
                DPuzzle.actualPlayer.GetComponent<Player>().isWalking = true;
                Player.trys = 2;
            }
            else if (DPuzzle.actualPlayer.tag.Equals("Maria"))
            {
                DPuzzle.actualPlayer = GameObject.FindGameObjectWithTag("Jose");
                Camera.main.GetComponent<CameraFollow>().target = DPuzzle.actualPlayer.transform;
                DPuzzle.actualPlayer.GetComponent<Player>().isWalking = true;
                Player.trys = 3;
            }
            else if (DPuzzle.actualPlayer.tag.Equals("Jose"))
            {
                Debug.Log("fssrhsdfhs");
                Application.LoadLevel(3);
            }
        }
    }

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.layer.Equals (10))
		{
			isWalking = true;
		}
		
	}


	// Use this for initialization
	void Start () {
        speed *= 1f / 100f;
        
	}
	
	// Update is called once per frame
	public override void Update () 
    {
        base.Update();
        
        if (isWalking)
        {
            GetComponent<Animator>().enabled = true;
            LookAt2D(current.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, current.transform.position, speed);
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
	}
}
