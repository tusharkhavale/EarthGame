﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour {

	public void OnMouseUp()
	{
		if (GameController.controller.WikipediaStatus())
			return;
		
		GameController.controller.SelectedCountry(gameObject);

	}
}
