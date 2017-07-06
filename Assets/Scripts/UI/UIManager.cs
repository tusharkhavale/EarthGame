using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private GameObject mainMenu;
	private GameObject wikiPanel;

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
		wikiPanel.transform.GetComponent<WikiPage> ().ZoomOut ();
		GameController.controller.earthManager.MoveToWikiPosition (false);
	}

	public void ShowWikiPanel()
	{
		wikiPanel.SetActive (true);
		StartCoroutine (GetData ());
	}


	string url = "https://en.wikipedia.org/w/api.php";
	string country;
	IEnumerator GetData()
	{
		country = GameController.controller.earthManager.SelectedCountry.name;
		WWWForm form = new WWWForm ();
		form.AddField ("action", "query");
		form.AddField ("prop", "revisions");
		form.AddField ("titles", country);
		form.AddField ("rvprop", "content");

		WWW w = new WWW(url, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.error);
		}
		else {
			wikiPanel.transform.GetComponent<WikiPage> ().Content = w.text.Substring (0, 1000);
			print("Done : "+w.text);
		}
	}

}
