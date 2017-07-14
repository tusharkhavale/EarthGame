using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour {

	private Transform earth;
	private GameObject selectedCountry;
	private Animator anim;

	void Awake()
	{
		GameController.controller.earthManager = this;
		LoadReferences ();
	}

	/// <summary>
	/// Loads all references.
	/// </summary>
	private void LoadReferences()
	{
		earth = transform.Find ("EarthCountries");
		anim = transform.GetComponent<Animator> ();
	}

	/// <summary>
	/// Gets or sets the selected country.
	/// </summary>
	/// <value>The selected country.</value>
	public GameObject SelectedCountry
	{
		set{
				HideCountry ();
				selectedCountry = value;
				GameController.controller.ShowCountryTitle ();
		   }
		get{ return selectedCountry; }
	}

	/// <summary>
	/// Disables mesh renderer of previously selected Country.
	/// </summary>
	/// <returns>The country.</returns>
	private void HideCountry()
	{
		if(SelectedCountry)
			SelectedCountry.transform.GetComponent<MeshRenderer> ().enabled = false;
		
	}

	/// <summary>
	/// Moves globe to wiki position.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void MoveToWikiPosition(bool value)
	{
		if (value)
			anim.enabled = value;
		anim.SetBool ("wikiPos", value);

	}

	/// <summary>
	/// Disable the Animator component when animation finishes
	/// </summary>
	public void DisabaleAnimation()
	{
		anim.enabled = false;
	}


}
