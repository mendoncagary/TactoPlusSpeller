using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOGWordReco : MonoBehaviour {

	public static AudioSource audio;
	public static string soundText;

	public static string EchoWord() {

		if (TextToSpeech.level == 2) {
			if (BReco.detected == true && AReco.detected == true && TReco.detected == true) {
				if ((BReco.position_X < AReco.position_X) && (AReco.position_X < TReco.position_X)) {
					soundText = "Yes! It's a Dog.";

				} else {
					soundText = "That's a good start, but wrong order.";
				}
				return soundText;
			} else {
				return "0";
			}
		}
		return "0";
	}



	public static IEnumerator LoadNextPanel(){


		yield return new WaitForSeconds (2f);
		TextToSpeech.level++;
		GameObject.Find ("Canvas").GetComponent<CanvasActivateObject>().DeactivateObjects();
		//level++;
		GameObject.Find ("Canvas").GetComponent<CanvasActivateObject>().ActivateObject("CatWordPanel");
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().DeactivateImageTargets();
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().ActivateTarget("ImageA");
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().ActivateTarget("ImageT");
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().ActivateTarget("ImageC");

	}
		
}
