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
			anim.SetBool ("zoomOut", false);
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

	public void ZoomOut()
	{
		anim.SetBool ("zoomOut", true);
	}

	private void HideWikiPanel()
	{
		gameObject.SetActive (false);
	}
}
