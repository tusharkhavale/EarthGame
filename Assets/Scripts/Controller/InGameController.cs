using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameController : MonoBehaviour {

	private Button btnPlay;
	private GameObject infoPopup;
	private GameObject taskPanel;

	void Awake()
	{
		GameController.controller.ingameController = this;
	}

	private void LoadUIReferences()
	{
		btnPlay = transform.Find ("Play").GetComponent<Button> ();
		infoPopup = transform.Find ("Popup").gameObject;
		taskPanel = transform.Find ("TaskPanel").gameObject;
	}

	private void AssignButtonDelegates()
	{
		btnPlay.onClick.AddListener (this.OnClickPlay);
	}

	private void OnClickPlay()
	{
		ShowInfoPopup ();
	}

	private void ShowInfoPopup()
	{
		infoPopup.SetActive (true);		
	}

	public void ShowTask(ECountry ECountry)
	{
		taskPanel.SetActive (true);
		taskPanel.transform.GetComponent<Text> ().text = "Find " + ECountry.ToString();
	}


}
