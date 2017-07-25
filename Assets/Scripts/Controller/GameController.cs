using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController controller;
	private EGameState gameState = EGameState.Globe;

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
	public GamePlay gameplay;

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

	public bool WikipediaStatus()
	{
		return uiManager.Wikipedia;
	}

	public void HideSelectedCountry()
	{
		earthManager.HideCountry ();
	}

	public void ToggleEarthType()
	{
		earthManager.ToggleEarthType ();
	}

	public void HideCountryTitle()
	{
		uiManager.HideCountryTitle ();
	}

	public void SelectedCountry(GameObject go)
	{
		if (gameState == EGameState.Globe) 
		{
			earthManager.SelectedCountry = go;
		}
		else if (gameState == EGameState.Game) 
		{
			gameplay.SelectedCountry (go);
		}
	}

	public void EnableStartButton(bool value)
	{
		ingameController.EnableStartButton (value);
	}
}
