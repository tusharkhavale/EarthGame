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
	private Animator anim;

	void Start()
	{
		LoadReferences ();
		AssignButtonDelegates ();
		StartCoroutine (GetData ());
	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	void LoadReferences()
	{
		anim = transform.GetComponent<Animator> ();
		panel = transform.Find ("Panel");
		btnNew = panel.Find ("New").GetComponent<Button> ();
		btnSettings = panel.Find ("Settings").GetComponent<Button> ();
		btnHelp = panel.Find ("Help").GetComponent<Button> ();
		btnExit = panel.Find ("Exit").GetComponent<Button> ();
	}

	/// <summary>
	/// Assigns the button delegates.
	/// </summary>
	void AssignButtonDelegates()
	{
		btnNew.onClick.AddListener (this.OnClickNew);
		btnSettings.onClick.AddListener (this.OnClickSettings);
		btnHelp.onClick.AddListener (this.OnClickHelp);
		btnExit.onClick.AddListener (this.OnClickExit);
	}


#region callback functions

	public void OnClickNew()
	{
		
	}

	public void OnClickSettings ()
	{
		
	}

	public void OnClickHelp()
	{
		
	}

	public void OnClickExit ()
	{
		anim.SetBool ("open", false);
	}

	public void OnLoad()
	{
		
	}

	public void OnExit()
	{
		gameObject.SetActive (false);
	}


#endregion



	string url = "https://en.wikipedia.org/w/api.php";

	IEnumerator GetData()
	{
		WWWForm form = new WWWForm ();
		form.AddField ("action", "query");
		form.AddField ("prop", "revisions");
		form.AddField ("titles", "India");
		form.AddField ("rvprop", "content");

		WWW w = new WWW(url, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.error);
		}
		else {
			print("Done : "+w.text);
		}
	}

}
