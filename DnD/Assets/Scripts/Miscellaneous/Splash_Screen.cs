using UnityEngine;
using System.Collections;

public class Splash_Screen : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip clip;
    static bool isKeyPressed;

    private void Update()
    {
        if(Input.anyKeyDown && isKeyPressed == false)
        {
            isKeyPressed = true;
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        Application.LoadLevel("Start Screen");
    }
}
