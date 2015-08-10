using UnityEngine;
using System.Collections;

public class VideoController : MonoBehaviour {

    MovieTexture movie;
    AudioSource audio;

    IEnumerator showVideo()
    {
        yield return new WaitForSeconds(1f);
        videoInitializer();
        StartCoroutine(endVideo());
    }

    IEnumerator endVideo()
    {
        yield return new WaitForSeconds(movie.duration);
        for (int i = 0; i < FindObjectsOfType<MenuController>().Length; i++)
            FindObjectsOfType<MenuController>()[i].selectButton(0);
    }


    void Start()
    {
        StartCoroutine(showVideo());
        movie = (MovieTexture)renderer.material.mainTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
    }

	public void videoInitializer()
    {
        movie.Play();
        audio.Play();
    }
}
