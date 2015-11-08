using UnityEngine;
using System.Collections;

public class Image_Rotator : MonoBehaviour {
    public GameObject image;
    public float transitionSpeed;

    private void Update()
    {
        if(image.transform.rotation.y >= 360)
        {
            image.transform.Rotate(0, 0, 0);
        }
        image.transform.Rotate(0, Vector3.one.y * transitionSpeed * Time.deltaTime, 0);
    }
}
