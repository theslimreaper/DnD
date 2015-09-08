using UnityEngine;
using System.Collections;

public class Screen_Rotator : MonoBehaviour {
	int currentScreen;
	public GameObject[] arms;
	public int transitionSpeed;
	int moving;
	// Use this for initialization
	void Start () {
	
		for(int i=0;i<arms.Length;i++)
		{
			arms[i].transform.Rotate(Vector3.up*(360/arms.Length*i));
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.LeftArrow))
		   {
			moving=-1;
			}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			moving=1;
		}
		if(moving!=0)
			{
				transform.Rotate(Vector3.up * transitionSpeed*moving);

				if(transform.rotation.eulerAngles.y%(360/arms.Length)<1)
				{
					moving=0;
				}
			}
	}

}
