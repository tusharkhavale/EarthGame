using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private GameObject mainMenu;
	private GameObject wikiPage;

	void Awake()
	{
		GameController.controller.uiManager = this;
	}

	void Start()
	{
		LoadReferences ();
		AddEscDelegate ();
	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	void LoadReferences()
	{
		mainMenu = transform.Find ("MainMenu").gameObject;
		wikiPage = transform.Find ("WikiPage").gameObject;
	}

	/// <summary>
	/// Shows Main Menu.
	/// </summary>
	public void ShowMenu ()
	{
		mainMenu.SetActive (true);
	}

	void AddEscDelegate()
	{
		GameController.controller.inputManager.AddEscDelegate (this.OnPressEsc);
	}

	void OnPressEsc()
	{
		mainMenu.SetActive (true);
	}

}
