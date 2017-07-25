using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour {

	private Transform earth;
	private Transform earthWater;
	private Transform earthBoundries;
	private GameObject selectedCountry;
	private Animator anim;
	public GameObject wikiPos;

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
		earthWater = transform.Find ("EarthWater");
		earthBoundries = transform.Find ("EarthBoundries");
		anim = transform.GetComponent<Animator> ();
	}

	/// <summary>
	/// Gets or sets the selected Country.
	/// </summary>
	/// <value>The selected Country.</value>
	public GameObject SelectedCountry
	{
		set{
				HideCountry ();
				selectedCountry = value;
				selectedCountry.transform.GetComponent<MeshRenderer> ().enabled = true;			
				GameController.controller.ShowCountryTitle ();
		   }
		get{ return selectedCountry; }
	}

	/// <summary>
	/// Disables mesh renderer of previously selected Country.
	/// </summary>
	/// <returns>The Country.</returns>
	public void HideCountry()
	{
		if(SelectedCountry)
			SelectedCountry.transform.GetComponent<MeshRenderer> ().enabled = false;
		
	}

	/// <summary>
	/// Toggles the type of the earth re	/// </summary>
	public void ToggleEarthType()
	{
		bool isActive = earthWater.gameObject.activeInHierarchy;
		earthWater.gameObject.SetActive (earthBoundries.gameObject.activeInHierarchy);
		earthBoundries.gameObject.SetActive (isActive);
	}

	/// <summary>
	/// Moves globe to wiki position.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void MoveToWikiPosition(bool value)
	{
#if UNITY_WEBGL || UNITY_EDITOR
//		anim.enabled = false;
//		StopAllCoroutines();
//		if(value)
//			StartCoroutine(TranslateGlobe(wikiPos.transform.position));
//		else
//			StartCoroutine(TranslateGlobe(Vector3.zero));
		if (value)
			anim.enabled = value;

		anim.SetBool ("wikiPos", value);

#else 
		if (value)
			anim.enabled = value;

		anim.SetBool ("wikiPos", value);
#endif

	}

	/// <summary>
	/// Disable the Animator component when animation finishes
	/// </summary>
	public void DisabaleAnimation()
	{
		anim.enabled = false;
	}

	/// <summary>
	/// Translates the globe to the destination.
	/// </summary>
	/// <returns>The globe.</returns>
	/// <param name="destination">Destination.</param>
	IEnumerator TranslateGlobe(Vector3 destination)
	{
		while (true) 
		{
			transform.position = Vector3.Lerp (transform.position, destination, 0.1f);
			if (transform.position == destination)
				break;
			yield return null;
		}
	}
}
