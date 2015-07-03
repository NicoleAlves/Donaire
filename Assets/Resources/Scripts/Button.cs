using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    public GameObject PauseCanvas;
    public GameObject GameCanvas;

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    public void Pause()
    {
        DPuzzle.actualPlayer.GetComponent<Player>().isWalking = !DPuzzle.actualPlayer.GetComponent<Player>().isWalking; 
        PauseCanvas.SetActive(!PauseCanvas.activeSelf);
        GameCanvas.SetActive(!GameCanvas.activeSelf);
    }

}
