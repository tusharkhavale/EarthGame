using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class Parser : MonoBehaviour {

	void Awake()
	{
		GameController.controller.parser = this;
	}

	/// <summary>
	/// Parses the json.
	/// {"batchcomplete":"","query":{"pages":{"14533":{"pageid":14533,"ns":0,"title":"India","extract":"Text description"}
	/// </summary>
	/// <returns>The json.</returns>
	/// <param name="json">Json.</param>
	public string ParseJson(string json)
	{
		Dictionary<string,object> main = Json.Deserialize(json) as Dictionary<string, object>;
		Dictionary<string,object> query = main["query"] as Dictionary<string,object>;
		Dictionary<string,object> pages = query ["pages"] as Dictionary<string,object>;
		string pageId = null;
		foreach (string key in pages.Keys) 
		{
			pageId = key;
		}
		Dictionary<string,object> id = pages [pageId] as Dictionary<string,object>;
		string text = id ["extract"] as string;
		text = text.Replace ("<p>", "");
		text = text.Replace ("</p>", "");
		text = text.Replace ("<span>", "/n");
		text = text.Replace ("</span>", "");

		return text;
	}

}
