using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class Character_Info : ScriptableObject {

	public static string characterClass = "";
	public static string characterRace = "";
	public static string characterName = "";
	public static string characterSubrace = "";
	public static string characterAlignment = "";
	public static string characterAge = "";
	public static string characterGender = "";
	public static string characterLevel = "";
	public static string characterHealth = "";
	public static string characterHeight = "";
	public static string characterWeight = "";
	public static string characterCarryWeight = "";
	public static string characterMoveSpeed = "";
	public static string characterLanguages = "";
    public static string characterCurrHealth = "";
    public static Sprite characterAvatar;
    public static int id = 0;
    public static int maxid = 0;
    public static int copper = 0;
    public static int silver = 0;
    public static int electrum = 0;
    public static int gold = 0;
    public static int platinum = 0;
	public static List<Item_Types> characterItems = new List<Item_Types>();
	public static List<Spell_Class> characterSpells = new List<Spell_Class>();
    public static string combatAC = "";
    public static string combatBAB = "";
    public static string combatInitiative = "";
    public static string combatReflex = "";
    public static string combatWill = "";
    public static string combatFortitude = "";
    public static string combatCMB = "";
    public static string combatCMD = "";
}
