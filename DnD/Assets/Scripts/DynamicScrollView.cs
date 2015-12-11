using UnityEngine;
using System.Collections;

public class DynamicScrollView : MonoBehaviour {
	public float lowestNumber=0;
	public float extraHeight = 0;
	// Use this for initialization
	public void Update()
	{
		int i = 0;
		foreach(Transform child in transform)
		{
			if(i==0)
				extraHeight=child.GetComponent<RectTransform>().rect.height;
			if(child.transform.position.y<lowestNumber)
			{
				lowestNumber=child.transform.localPosition.y;
				extraHeight=child.GetComponent<RectTransform>().rect.height;
			}
			i++;
		}
		i = 0;
		//print ("The lowest number found was: " + lowestNumber + "\nThe Extra Height is: " + extraHeight);
		this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, extraHeight-lowestNumber);
	}
}
