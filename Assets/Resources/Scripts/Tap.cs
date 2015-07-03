using UnityEngine;
using System.Collections;

public class Tap : Default {
    public int clickTimes = 0;
    public bool canClick = true;
	
	public override void OnTouch(Touch t, Vector3 p)
	{
        if (Input.GetMouseButtonDown(0))
        {
            clickTimes++;
        }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public override void Update()
    {
		base.Update ();
	}
}