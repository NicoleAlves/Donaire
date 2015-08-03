using UnityEngine;
using System.Collections;

public class DragDrop : Default {
    Vector3 startPosition;
    public GameObject match;
    public bool wasTouched = false;
    public bool matchAttached = false;
    public bool canMatch;
    public bool canFollow = false;
    public Vector3 matchedPosition;
    Vector3 pointerPos;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals(match.name) && canMatch && !matchAttached)
        {
            matchAttached = true;
            transform.localPosition = matchedPosition;
        }

    }
	

    public override void OnTouch(Touch t, Vector3 p)
    {
        if (Input.GetButton("Fire1") && !matchAttached)
        {
            pointerPos = p; 
            wasTouched = true;
        }
    }

	// Use this for initialization
	void Start () {
       startPosition =  transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (wasTouched && Input.GetButton("Fire1") && !matchAttached)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
        }
        else { wasTouched = false; }

        if (!matchAttached)
        {
            base.Update();
            if (!wasTouched) transform.position = startPosition;
        }
	}
}
