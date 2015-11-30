using UnityEngine;
using System.Collections;

public class Credits_Scroller : MonoBehaviour {
    public GameObject credits;
    public float speed = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        credits.transform.position= new Vector3 (credits.transform.position.x,credits.transform.position.y+.5f*speed,credits.transform.position.z);
        float position = ( credits.transform.position.y - ((700*Screen.height) / 1080));
        if(position > Screen.height)
        {
            Application.LoadLevel("Start Screen");
        }
	}
}
