using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameController : MonoBehaviour {

	private Button btnStart;
	private Button btnPlay;
	private Button btnNext;
	private Button btnGameOver;
	private GameObject infoPopup;
	private GameObject taskPanel;
	private GameObject correctSelectionPopup;
	private GameObject gameOverPopup;
	private GameObject levelIndicator;
	private GameObject scoreIndicator;
	private Text levelIndicatorText;
	private Text scoreIndicatorText;
	private GamePlay gameplay;
	private Slider timebar;

	void Awake()
	{
		GameController.controller.ingameController = this;
	}

	void Start()
	{
		LoadUIReferences ();
		AssignButtonDelegates ();
	}

	private void LoadUIReferences()
	{
		btnStart = transform.Find ("Start").GetComponent<Button> ();
		infoPopup = transform.Find ("PopUp").gameObject;
		taskPanel = transform.Find ("TaskPanel").gameObject;
		gameOverPopup = transform.Find ("GameOver").gameObject;
		levelIndicator = transform.Find ("Level").gameObject;
		levelIndicatorText = levelIndicator.transform.Find ("Number").GetComponent<Text> ();
		scoreIndicator = transform.Find ("Score").gameObject;
		scoreIndicatorText = scoreIndicator.transform.Find ("Number").GetComponent<Text> ();
		timebar = taskPanel.transform.GetComponentInChildren<Slider> ();
		correctSelectionPopup = transform.Find ("CorrectSelection").gameObject;
		btnPlay = infoPopup.transform.GetComponentInChildren<Button> ();
		btnNext = correctSelectionPopup.transform.GetComponentInChildren<Button> ();
		btnGameOver = gameOverPopup.transform.GetComponentInChildren<Button> ();
		gameplay = transform.GetComponent<GamePlay> ();
	}

	private void AssignButtonDelegates()
	{
		btnStart.onClick.AddListener (this.OnClickStart);
		btnPlay.onClick.AddListener (this.OnClickPlay);
		btnNext.onClick.AddListener (this.OnClickNext);
		btnGameOver.onClick.AddListener (this.OnClickGameOver);
	}

	private void OnClickStart()
	{
		GameController.controller.GameState = EGameState.Game;
		GameController.controller.HideCountryTitle ();
		ShowInfoPopup ();
		btnStart.gameObject.SetActive (false);
	}

	private void OnClickPlay()
	{
		infoPopup.SetActive (false);
		gameplay.ResetVariables ();
		gameplay.SelectCountry ();
	}

	private void OnClickNext()
	{
		correctSelectionPopup.SetActive (false);
		gameplay.SelectCountry ();
	}

	private void OnClickGameOver()
	{
		gameOverPopup.SetActive (false);
		levelIndicator.SetActive (false);
		scoreIndicator.SetActive (false);
		GameController.controller.GameState = EGameState.Globe;
		btnStart.gameObject.SetActive (true);
	}

	private void ShowInfoPopup()
	{
		infoPopup.SetActive (true);		
	}

	public void ShowCorrectSelectionPop()
	{
		correctSelectionPopup.SetActive (true);
		taskPanel.SetActive (false);
	}

	public void ShowGameOverPopup()
	{
		gameOverPopup.SetActive (true);
		taskPanel.SetActive (false);
	}

	public void ShowTask(ECountry ECountry)
	{
		taskPanel.SetActive (true);
		taskPanel.transform.GetComponentInChildren<Text> ().text = "Find " + ECountry.ToString();
	}

	public void SetTimeBar(float value)
	{
		timebar.value = value;
	}

	public void EnableStartButton(bool value)
	{
		btnStart.interactable = value;
	}

	public void SetLevelDisplay(int i)
	{
		levelIndicator.SetActive (true);
		levelIndicatorText.text = "" + i;
	}

	public void SetScoreDisplay(int i)
	{
		scoreIndicator.SetActive (true);
		scoreIndicatorText.text = "" + i;
	}
}
