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
	}
}
