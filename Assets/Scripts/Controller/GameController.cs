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

	void Awake()
	{
		controller = this;
	}

	public void ShowWikiPanel()
	{
		uiManager.ShowWikiPanel ();
	}

}
