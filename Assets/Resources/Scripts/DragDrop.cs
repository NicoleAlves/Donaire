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
	

    public override void OnTouch(object t)
    {
        if(t is Touch)
        {
            if ( !matchAttached)
            {
                pointerPos = ((Touch)t).position; 
                wasTouched = true;
            }
        }
        else if (t is Vector3)
        {
            if (Input.GetButton("Fire1") &&  !matchAttached)
            {
                pointerPos = ((Vector3)t);
                wasTouched = true;
            }
        }
    }
	void Start () {
       startPosition =  transform.position;
	}
	void Update () {

        if (Input.touchSupported && Input.GetTouch(0).position != null)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
        }
        else if (wasTouched && Input.GetButton("Fire1") && !matchAttached)
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
