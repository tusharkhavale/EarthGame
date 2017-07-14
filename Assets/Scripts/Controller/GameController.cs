using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController controller;

	[HideInInspector]
	public UIManager uiManager;

	[HideInInspector]
	public InputManager inputManager;

	[HideInInspector]
	public EarthManager earthManager;

	[HideInInspector]
	public NetworkManager networkManager;

	[HideInInspector]
	public Parser parser;

	void Awake()
	{
		controller = this;
	}

	public void MoveEarthToWikiPosition(bool value)
	{
		earthManager.MoveToWikiPosition (value);
	}

	public void ShowCountryTitle()
	{
		uiManager.ShowCountryTitle ();
	}

	public void GetDataFromWikipedia()
	{
		networkManager.GetDataFromWikipedia ();
	}

	public string ParseJson(string json)
	{
		return parser.ParseJson (json);
	}

	public void AssignWikiText(string text)
	{
		uiManager.AssignWikiText (text);
	}

	public bool WikipediaStatus()
	{
		return uiManager.Wikipedia;
	}

}
