using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController controller;
	private EGameState gameState;

	[HideInInspector]
	public UIManager uiManager;

	[HideInInspector]
	public InputManager inputManager;

	[HideInInspector]
	public EarthManager earthManager;

	[HideInInspector]
	public NetworkManager networkManager;

	[HideInInspector]
	public InGameController ingameController;

	[HideInInspector]
	public Parser parser;

	void Awake()
	{
		controller = this;
	}

	/// <summary>
	/// Gets or sets the state of the game.
	/// </summary>
	/// <value>The state of the game.</value>
	public EGameState GameState
	{
		get{return gameState;}
		set{gameState = value;}
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

	public void AssignOverlayUIReference(OverlayUI overlayUI)
	{
		uiManager.AssignOverlayUIRefrence(overlayUI);
	}

	public bool WikipediaStatus()
	{
		return uiManager.Wikipedia;
	}


}
