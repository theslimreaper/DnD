using UnityEngine;
using System.Collections;

public class DynamicScrollView : MonoBehaviour {
	public float lowestNumber=0;
	public float extraHeight = 0;
	// Use this for initialization
	public void FixedUpdate()
	{
		int i = 0;
		foreach(RectTransform child in transform)
		{
			if(i==0)
				extraHeight=child.GetComponent<RectTransform>().rect.height;
			if(child.transform.localPosition.y<lowestNumber)
			{
				lowestNumber=child.transform.localPosition.y;
				extraHeight=child.GetComponent<RectTransform>().rect.height;
			}
			//print ("The number found was: " +child.transform.localPosition.y);
			i++;
		}
		i = 0;
		//print ("The lowest number found was: " + lowestNumber + "\nThe Extra Height is: " + extraHeight);
		this.GetComponent<RectTransform>().sizeDelta = new Vector2(0, extraHeight-lowestNumber);
	}
}
