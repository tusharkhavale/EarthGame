using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayUI : MonoBehaviour {

	void Awake()
	{
		GameController.controller.AssignOverlayUIReference (this);
	}
}
