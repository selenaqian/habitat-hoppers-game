﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWatcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape")) {
			Debug.Log ("Application will now exit...");	
			Application.Quit ();
		}
	}
}
