using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum EGameMode
{
	RUNNING,
	PAUSED
}
public class GamePlay : MonoBehaviour {

	private InGameController ingameController;
	private Player player;
	private List <int> lstUsedIndexes = new List<int>();
	private List<ECountry> lstCurrCountry;
	private ECountry currCountry;
	private Material red;
	private Material green;
	private EGameMode gameMode = EGameMode.PAUSED;
	private GameObject preSelection;
	private int level;

	void Awake()
	{
		GameController.controller.gameplay = this;
		ingameController = transform.GetComponent<InGameController> ();
	}

	void Start()
	{
		LoadMaterials ();
	}

	/// <summary>
	/// Loads the materials.
	/// </summary>
	private void LoadMaterials()
	{
		red = Resources.Load<Material> ("Materials/red");	
		green = Resources.Load<Material> ("Materials/green");	
	}


	/// <summary>
	/// Resets all variables.
	/// </summary>
	public void ResetVariables()
	{
		player = null;
		player = new Player ();
		ClearUsedIndexes ();
		lstCurrCountry = GetCountryList ();
		level = GetLevel();
	}

	/// <summary>
	/// Clears the used indexes list.
	/// </summary>
	private void ClearUsedIndexes()
	{
		lstUsedIndexes.Clear();
	}

	/// <summary>
	/// Selects the country for player to search.
	/// </summary>
	public void SelectCountry()
	{
		
		int index = 0;
		bool isValidIndex = false;

		// Update country list if level has changed
		if (level != GetLevel ()) 
		{
			level = GetLevel ();
			ClearUsedIndexes();
			lstCurrCountry = GetCountryList ();
		}

		// Clear used indexes list if all indexes are exhausted
		if (lstCurrCountry.Count <= lstUsedIndexes.Count) 
		{
			ClearUsedIndexes();
		}

		// select random index of the countries list
		while (!isValidIndex) 
		{
			index = Random.Range (0, lstCurrCountry.Count);
			isValidIndex = IsValidIndex (index);
		}

		// Add index to used index list
		lstUsedIndexes.Add (index);

		// Show player country name to be searched
		currCountry = lstCurrCountry[index];
		ingameController.SetTimeBar (1.0f);
		ingameController.ShowTask (lstCurrCountry[index]);
		ingameController.SetLevelDisplay (GetLevel ());
		ingameController.SetScoreDisplay (player.score);
		StartTimer ();
	}

	/// <summary>
	/// Add level time to remaining time.
	/// Start timer coroutine
	/// </summary>
	private void StartTimer()
	{
		player.time = Constants.dictTimePerLevel [GetLevel()];

		StopAllCoroutines ();
		StartCoroutine (RunTimer());
	}

	/// <summary>
	/// Runs the timer.
	/// </summary>
	/// <returns>The timer.</returns>
	IEnumerator RunTimer()
	{
		yield return new WaitForSeconds (1.0f);
		gameMode = EGameMode.RUNNING;
		float totalTime = player.time;
		while (true) 
		{
			player.time -= Time.deltaTime;
			ingameController.SetTimeBar (player.time/totalTime);
			ingameController.SetTimeDisplay ((int)(player.time / 1));
			if (player.time <= 0) 
			{
				GameOver ();
				break;
			}
			yield return null;
		}
	}

	/// <summary>
	/// Game ends.
	/// </summary>
	private void GameOver()
	{
		gameMode = EGameMode.PAUSED;
		HideCountry ();
		ingameController.ShowGameOverPopup ();
	}

	/// <summary>
	/// Determines whether this instance is valid index the specified index.
	/// </summary>
	/// <returns><c>true</c> if this instance is valid index the specified index; otherwise, <c>false</c>.</returns>
	/// <param name="index">Index.</param>
	private bool IsValidIndex(int index)
	{
		foreach (int i in lstUsedIndexes) 
		{
			if (index == i)
				return false;
		}
		return true;
	}

	/// <summary>
	/// Gets the country list based on the users level.
	/// </summary>
	/// <returns>The country list.</returns>
	private List<ECountry> GetCountryList()
	{
		return Constants.dictCountryList[GetLevel()];
	}

	/// <summary>
	/// Gets the level .
	/// </summary>
	/// <returns>The level.</returns>
	private int GetLevel()
	{
		for (int i = 2; i <= 11; i++) 
		{
			if (player.level < i )
				return i-1;
		}
		return 1;
	}

	/// <summary>
	/// Checks the selected country
	/// </summary>
	/// <param name="go">Go.</param>
	public void SelectedCountry(GameObject go)
	{
		if (gameMode == EGameMode.PAUSED)
			return;

		HideCountry ();
		preSelection = go;

		if (go.name == currCountry.ToString ())
			CorrectSelection (go);
		else
			IncorrectSelection (go);

		// selected country mesh
		go.transform.GetComponent<MeshRenderer> ().enabled = true; 
	}

	/// <summary>
	/// Stop time on correct selection.
	/// Start next task
	/// </summary>
	private void CorrectSelection(GameObject go)
	{
		gameMode = EGameMode.PAUSED;
		go.transform.GetComponent<MeshRenderer> ().material = green;
		// STops timer
		StopAllCoroutines ();
		IncrementLevel ();
		CalculateScore ();
		ingameController.ShowCorrectSelectionPop();

	}

	private void CalculateScore()
	{
		player.score += (int)(player.time * 100);
		ingameController.SetScoreDisplay (player.score);
	}

	/// <summary>
	/// Deducts time from total time.
	/// </summary>
	private void IncorrectSelection(GameObject go)
	{
		go.transform.GetComponent<MeshRenderer> ().material = red;
		player.time -= 10.0f;
	}

	private void IncrementLevel()
	{
		player.level += player.levelIncrementer;
	}

	private void HideCountry()
	{
		if (preSelection != null)
			preSelection.GetComponent<MeshRenderer> ().enabled = false;
	}
}
