using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour {

	Transform earth;
	GameObject selectedCountry;

	void Awake()
	{
		GameController.controller.earthManager = this;
	}

	/// <summary>
	/// Loads all references.
	/// </summary>
	private void LoadReferences()
	{
		earth = transform.Find ("EarthCountries");
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

}
