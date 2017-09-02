using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateImageTarget : MonoBehaviour {

	//public GameObject ImageC;
	//public GameObject ImageB;
	//public GameObject ImageA;
	//public GameObject ImageT;
	//public int word = 2;

	public void DeactivateImageTargets( ){

		GameObject parent = GameObject.Find ("ARCamera");
	//GameObject ImageC = GameObject.Find ("ImageC");
	//GameObject ImageB = GameObject.Find ("ImageA");
	//GameObject ImageT = GameObject.Find ("ImageT");
	//GameObject ImageA = GameObject.Find ("ImageA");
	//	GameObject ImageC = GameObject.Find("ImageC");
		//GameObject ImageB;
	//	GameObject ImageA = GameObject.Find("ImageA");
		/*
		//ActivateImageTarget ait = new ActivateImageTarget ();
		if (ImageC.active)
 		{		
			//ActivateImageTarget ait = new ActivateImageTarget ();
			ImageC.active = false;
		}
		if (ImageA.activeSelf)
		{		
			//ActivateImageTarget ait = new ActivateImageTarget ();
			ImageA.SetActive (false);
		}
		*/
		for(int i=0; i< parent.transform.childCount; i++)
		{
			var child = parent.transform.GetChild(i).gameObject;
			if(child != null && child.name!="Camera")
				child.SetActive(false);
		}


		//yield return new WaitForSeconds (1f);

	}
		
	public void ActivateTarget (string objectName) {
		//boolVariable.CardDetected = true;
		//Debug.Log(ImageTargetPlayAudio.CardDetected);
		//if (ImageTargetPlayAudio.CardDetected == true) {
		string name = objectName;

		GameObject parent = GameObject.Find ("ARCamera");
		for (int i = 0; i < parent.transform.childCount; i++) {
			var child = parent.transform.GetChild (i).gameObject;
			if (child != null) {
				if (child.name == name) {
					child.SetActive(true);
			}
			}
			
		}

	}
}
