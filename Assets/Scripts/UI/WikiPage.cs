using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WikiPage : MonoBehaviour {

	private Text txtContent;
	private Animator anim;

	void Start()
	{
		LoadReferences ();
	}

	void OnEnable()
	{
		if (anim)
			ZoomOut(false);
	}

	/// <summary>
	/// Loads all references.
	/// </summary>
	void LoadReferences()
	{
		anim = transform.GetComponent<Animator> ();
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

	/// <summary>
	/// Zooms out earth.
	/// </summary>
	public void ZoomOut(bool value)
	{
		anim.SetBool ("zoomOut", value);
	}

	/// <summary>
	/// Hides the wiki panel when zoom out animation finishes.
	/// </summary>
	private void HideWikiPanel()
	{
		gameObject.SetActive (false);
	}

}
