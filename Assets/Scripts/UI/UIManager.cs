using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private GameObject mainMenu;
	private GameObject wikiPanel;
	private GameObject header;
	private Button btnInfo;
	private bool wikipedia;

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
		wikiPanel = transform.Find ("WikiPage").gameObject;
		header = transform.Find ("Header").gameObject;
		btnInfo = header.transform.GetComponentInChildren<Button> ();
		btnInfo.onClick.AddListener (this.ShowWikiPanel);
	}

	/// <summary>
	/// Gets or sets a value for Wikipedia panel status.
	/// </summary>
	/// <value><c>true</c> if wikipedia; otherwise, <c>false</c>.</value>
	public bool Wikipedia
	{
		get{return wikipedia;}
		set{wikipedia = value;}
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
//		mainMenu.SetActive (true);
		HideWikiPanel();
	}

	private void HideWikiPanel()
	{
		wikiPanel.transform.GetComponent<WikiPage> ().ZoomOut (true);
		GameController.controller.MoveEarthToWikiPosition (false);
		Wikipedia = false;
	}

	public void ShowWikiPanel()
	{
		Wikipedia = true;
		wikiPanel.SetActive (true);
		GameController.controller.MoveEarthToWikiPosition (true);
		GameController.controller.GetDataFromWikipedia ();
	}

	public void AssignWikiText(string text)
	{
		wikiPanel.transform.GetComponent<WikiPage> ().Content = text;
	}

	public void ShowCountryTitle()
	{
		header.SetActive(true);
		header.transform.GetComponentInChildren<Text>().text = GameController.controller.earthManager.SelectedCountry.name;
	}

}
