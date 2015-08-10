using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour 
{
    public RectTransform[] positions;
    public RectTransform playerRect;
    public int actualIndexer = 0;

    public void LoadNextLevel(int i)
    {
        StartCoroutine(LevelLoad(i));
    }

    //load level after one second delay
    IEnumerator LevelLoad(int i)
    {
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(i);
    }

    public void selectButton(int i)
    {
        if (actualIndexer != i)
        {
            actualIndexer = i;
            if(positions.Length != 0)playerRect.position = new Vector2(positions[actualIndexer].position.x, playerRect.position.y);
        }
        else
        {
            GetComponent<Animator>().Play("PanelFadeOut");
            LoadNextLevel(actualIndexer);
        }
    }

}
