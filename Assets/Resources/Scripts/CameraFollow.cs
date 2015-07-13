using UnityEngine;
using System.Collections;

public class CameraFollow : Default
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    public float offSetTop;
    public float offSetLeft;

    void Start()
    {
        Look();
    }

    // Update is called once per frame
    void Update()
    {
        if(target.tag.Equals("Jose"))
        {
            Vector3 f = DPuzzle.actualPlayer.GetComponent<Player>().current.transform.position;
        }
        if (target)
        {
            /*Vector3 point = camera.WorldToViewportPoint(target.localPosition );
            transform.position = Vector3.MoveTowards(transform.localPosition , t, 2f);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + (delta);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);*/
            Vector3 t = new Vector3(target.position.x, target.position.y, -10);
            Move(new Vector3(10f, 0, 0), target.position);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }

    public void Look()
    {
        GetComponent<Camera>().orthographicSize = 9;
    }

    public void Move(Vector3 percentScreen,Vector3 target)
    {
        //Vector3 percentWorld = Camera.main.ViewportToWorldPoit(percentScreen);
        Vector3 newTarget = new Vector3(target.x + offSetLeft, target.y + offSetTop, target.z);
        transform.rotation = DPuzzle.actualPlayer.transform.rotation;
        transform.position = Vector3.MoveTowards(transform.position, newTarget, 1f);

    }

}