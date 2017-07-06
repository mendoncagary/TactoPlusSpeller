using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActivateObject : MonoBehaviour {

	public GameObject CatWordPanel;
	public GameObject MainMenuPanel;

	// Use this for initialization
	void Start () {
		//boolVariable.CardDetected = true;
		Debug.Log(ImageTargetPlayAudio.CardDetected);
		if (ImageTargetPlayAudio.CardDetected == true) {
			MainMenuPanel.SetActive (false);
			CatWordPanel.SetActive (true);	


		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
