﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController controller;

	[HideInInspector]
	public UIManager uiManager;

	void Awake()
	{
		controller = this;
	}


}