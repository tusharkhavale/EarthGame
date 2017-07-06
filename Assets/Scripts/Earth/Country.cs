using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour {

	public void OnMouseUp()
	{
		GameController.controller.earthManager.SelectedCountry = gameObject;
		(transform.GetComponent<MeshRenderer> ()).enabled = true; 
	}
}
