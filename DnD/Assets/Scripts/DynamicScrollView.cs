using UnityEngine;
using System.Collections;

public class DynamicScrollView : MonoBehaviour {
	float lowestNumber=0;
	float extraHeight = 0;
	// Use this for initialization
	public void Update()
	{
		foreach(Transform child in transform)
		{
			if(child.transform.position.y<lowestNumber)
			{
				lowestNumber=child.transform.localPosition.y;
				extraHeight=child.GetComponent<RectTransform>().rect.height;
			}
		}
		//print ("The lowest number found was: " + lowestNumber + "\nThe Extra Height is: " + extraHeight);
		this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width, extraHeight-lowestNumber);
	}
}
