using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	private string url = "https://en.wikipedia.org/w/api.php";
	private string country;

	void Awake()
	{
		GameController.controller.networkManager = this;
	}

	/// <summary>
	/// Starts coroutine to get data from wikipedia.
	/// </summary>
	public void GetDataFromWikipedia()
	{
		StartCoroutine (GetData ());
	}

	/// <summary>
	/// Gets the data.
	/// </summary>
	/// <returns>The data.</returns>
	IEnumerator GetData()
	{
		country = GameController.controller.earthManager.SelectedCountry.name;
		WWWForm form = new WWWForm ();
		form.AddField ("action", "query");
		form.AddField ("format", "json");
		form.AddField ("prop", "extracts");
		form.AddField ("exintro", "explaintext");
		form.AddField ("titles", country);

		WWW w = new WWW(url, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) 
		{
			print(w.error);
		}
		else 
		{
			Debug.Log("Done : "+w.text);
			GameController.controller.AssignWikiText (GameController.controller.ParseJson (w.text));
		}
	}


}
