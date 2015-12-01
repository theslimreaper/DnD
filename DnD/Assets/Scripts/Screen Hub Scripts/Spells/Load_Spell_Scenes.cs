using UnityEngine;
using System.Collections;

public class Load_Spell_Scenes : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//Go from spell scene to main scene
	public void SpellToMain ()
	{
		Application.LoadLevel ("Screen Hub");
	}

	public void MainToSpell ()
	{
		Application.LoadLevel ("Spell Selection");
	}
}

