using UnityEngine;
using System.Collections;

public class DragDrop : Default {
    Vector3 startPosition;
    public GameObject match;
    public bool isTouched = false;
    public bool matchAttached = false;
    public bool canMatch;
    public Vector3 matchedPosition;

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.Equals(match) && canMatch && !matchAttached)
        {
            matchAttached = true;
            transform.localPosition = matchedPosition;
        }

    }
	

    public override void OnTouch(Touch t, Vector3 p)
    {
        if (Input.GetButton("Fire1") && !matchAttached)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3( p.x,p.y,0));
            transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
            isTouched = true;
        }
    }

	// Use this for initialization
	void Start () {
       startPosition =  transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!matchAttached)
        {
            isTouched = false;
            base.Update();
            if (!isTouched) transform.position = startPosition;
        }
	}
}
