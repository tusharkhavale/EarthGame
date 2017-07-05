using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private GameObject mainMenu;

	void Awake()
	{
	}

	void Start()
	{
		GameController.controller.uiManager = this;
		LoadReferences ();
		AddEscDelegate ();
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

	void AddEscDelegate()
	{
		//GameController.controller.inputManager.AddEscDelegate (this.OnPressEsc);
	}

	void OnPressEsc()
	{
		mainMenu.SetActive (true);
	}

}
