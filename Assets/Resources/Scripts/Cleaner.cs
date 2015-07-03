using UnityEngine;
using System.Collections;

public class Cleaner : Default {
    public bool isVisible = true;
    public SpriteRenderer sprt;
    float alpha = 1;
    public float speed = 0.2f;
	// Use this for initialization
	void Start () {
	
	}

    public override void OnTouch(Touch t, Vector3 m)
    {

        if(isVisible && alpha > 0)
        {
            alpha -= 0.01f * speed;
            sprt.color = new Color(sprt.color.r, sprt.color.g, sprt.color.b, alpha);
        }
        else
        {
            isVisible = false;
            alpha = 0;
        }
    }

	// Update is called once per frame
    public override void Update()
    {
        base.Update();
        
	}
}
