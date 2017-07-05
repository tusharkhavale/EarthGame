using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private GameObject mainMenu;

	void Awake()
	{
		GameController.controller.uiManager = this;
	}

	void Start()
	{
		LoadReferences ();
	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	void LoadReferences()
	{
		mainMenu = transform.Find ("MainMenu").gameObject;
	}

	/// <summary>
	/// Shows Main Menu.
	/// </summary>
	public void ShowMenu ()
	{
		mainMenu.SetActive (true);
	}
}
