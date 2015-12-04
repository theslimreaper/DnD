using UnityEngine;
using System.Collections;

public class TransitionToLevelUp : MonoBehaviour {
	public void LevelUp()
	{
		Character_Info.characterLevel=(System.Convert.ToInt32(Character_Info.characterLevel)+1).ToString();
		Application.LoadLevel ("Level up Scene");
	}
}
