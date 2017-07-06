using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WikiPage : MonoBehaviour {

	private Text txtContent;

	/// <summary>
	/// Loads all references.
	/// </summary>
	void LoadReferences()
	{
		txtContent = transform.Find ("Bg").Find ("TextScroll").Find ("Viewport").GetComponentInChildren<Text> ();
	}

	/// <summary>
	/// Gets or sets the text content.
	/// </summary>
	/// <value>The content.</value>
	public string Content
	{
		set{txtContent.text = value;}
		get{return txtContent.text;}
	}

}
