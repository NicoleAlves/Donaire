using UnityEngine;
using System.Collections;

public class CompletePuzzle : MonoBehaviour {

    public void executeSound()
    {
        GetComponent<AudioSource>().Play();
    }

}
