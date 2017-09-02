using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActivateObject : MonoBehaviour {

	//public GameObject MainMenuPanel;
	//public GameObject CatWordPanel;
	//public static int level = 0;

	// Use this for initialization
	public void ActivateObject(string objectName) {

//		GameObject parent = GameObject.Find ("Canvas");
		//GameObject MainMenuPanel = GameObject.Find ("MainMenuPanel");
		//GameObject CatWordPanel = GameObject.Find ("CATWordPanel");
		//boolVariable.CardDetected = true;
		string name = objectName;

		for(int i=0; i< gameObject.transform.childCount; i++)
		{
			var child = gameObject.transform.GetChild(i).gameObject;
			if(child != null && child.name==name)
				child.SetActive(true);
		}


		//Debug.Log(ImageTargetPlayAudio.CardDetected);
	//	Debug.Log("hello");
		// caoq = new CanvasActivateObject ();
		//CatWordPanel.SetActive (false);	
		//if (level == 0) {
			
		//	MainMenuPanel.SetActive (true);
		//}
		
	}

	public void DeactivateObjects(){
		for(int i=0; i< gameObject.transform.childCount; i++)
		{
			var child = gameObject.transform.GetChild(i).gameObject;
			if(child != null)
				child.SetActive(false);
		}


	}
	

}
