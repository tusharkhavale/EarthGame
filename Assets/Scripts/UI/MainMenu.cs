using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	private Transform panel;
	private Button btnNew;
	private Button btnSettings;
	private Button btnHelp;
	private Button btnExit;

	void Start()
	{
		LoadReferences ();
		AssignButtonDelegates ();
	}


	/// <summary>
	/// Loads the references.
	/// </summary>
	void LoadReferences()
	{
		panel = transform.Find ("Panel");
		btnNew = panel.Find ("Play").GetComponent<Button> ();
		btnSettings = panel.Find ("Explore").GetComponent<Button> ();
		btnHelp = panel.Find ("Help").GetComponent<Button> ();
		btnExit = panel.Find ("Exit").GetComponent<Button> ();
	}

	/// <summary>
	/// Assigns the button delegates.
	/// </summary>
	void AssignButtonDelegates()
	{
		btnNew.onClick.AddListener (this.OnClickPlay);
		btnSettings.onClick.AddListener (this.OnClickExplore);
		btnHelp.onClick.AddListener (this.OnClickHelp);
		btnExit.onClick.AddListener (this.OnClickExit);
	}


#region callback functions

	public void OnClickPlay()
	{
		GameController.controller.GameState = EGameState.Game;
	}

	public void OnClickExplore ()
	{
		GameController.controller.GameState = EGameState.Globe;

	}

	public void OnClickHelp()
	{
		
	}

	public void OnClickExit ()
	{
	}

	public void OnExit()
	{
		gameObject.SetActive (false);
	}

#endregion
}
