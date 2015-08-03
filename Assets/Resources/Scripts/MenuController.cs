using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour 
{
    public RectTransform[] positions;
    public RectTransform playerRect;
    public int actualIndexer = 0; 

    void Start()
    {
        GetComponent<Animator>().SetInteger("fadeType", 1 );
    }

    public void enterScene()
    {
        GetComponent<Animator>().SetInteger("fadeType", 2);
        GetComponent<Image>().enabled = false;
    }
        
    public void outScene()
    {
        Application.LoadLevel(actualIndexer);
    }

    public void selectButton(int i)
    {
        if (actualIndexer != i)
        {
            actualIndexer = i;
            playerRect.position = new Vector2(positions[actualIndexer].position.x, playerRect.position.y);
        }
        else 
        {
            GameObject.FindGameObjectWithTag("fadeObj").GetComponent<Image>().enabled = true;
            GameObject.FindGameObjectWithTag("fadeObj").GetComponent<Animator>().SetInteger("fadeType", 0);
        }
    }
}
