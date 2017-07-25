using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private InGameController inGameController;
	private GameObject wikiPanel;
	private GameObject header;
	private Button btnInfo;
	private Button btnClose;
	private bool wikipedia;
	private Button btnToggleEarth; 

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
		wikiPanel = transform.Find ("WikiPage").gameObject;
		header = GameController.controller.ingameController.transform.Find ("Header").gameObject;
		btnToggleEarth = GameController.controller.ingameController.transform.Find ("ToggleEarth").GetComponent<Button>();
		btnToggleEarth.onClick.AddListener (this.ToggleEarthType);
		btnInfo = header.transform.GetComponentInChildren<Button> ();
		btnInfo.onClick.AddListener (this.ShowWikiPanel);
		btnClose = wikiPanel.transform.Find("Bg").GetComponentInChildren<Button> ();
		btnClose.onClick.AddListener (this.HideWikiPanel);
	}

	public void ToggleEarthType()
	{
		GameController.controller.ToggleEarthType ();
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

	void AddEscDelegate()
	{
		GameController.controller.inputManager.AddEscDelegate (this.OnPressEsc);
	}

	void OnPressEsc()
	{
		HideWikiPanel();
	}

	private void HideWikiPanel()
	{
		GameController.controller.EnableStartButton (true);
		wikiPanel.transform.GetComponent<WikiPage> ().ZoomOut (true);
		GameController.controller.MoveEarthToWikiPosition (false);
		Wikipedia = false;
		header.SetActive (false);
		GameController.controller.HideSelectedCountry ();
	}

	public void ShowWikiPanel()
	{
		GameController.controller.EnableStartButton (false);
		Wikipedia = true;
		wikiPanel.SetActive (true);
		GameController.controller.MoveEarthToWikiPosition (true);
		GameController.controller.GetDataFromWikipedia ();
	}

	public void AssignWikiText(string text)
	{
		wikiPanel.transform.GetComponent<WikiPage> ().Content = text;
	}

	public void HideCountryTitle()
	{
		header.SetActive(false);
	}

	public void ShowCountryTitle()
	{
		header.SetActive(true);
		header.transform.GetComponentInChildren<Text>().text = GameController.controller.earthManager.SelectedCountry.name;
	}

}
