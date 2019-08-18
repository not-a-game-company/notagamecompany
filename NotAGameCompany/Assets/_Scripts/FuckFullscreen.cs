using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckFullscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Screen.fullScreen )
			Screen.fullScreen = !Screen.fullScreen;
		else
		{
			Screen.fullScreen = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
