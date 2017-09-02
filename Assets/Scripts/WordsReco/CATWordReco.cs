using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CATWordReco : MonoBehaviour {

	public static AudioSource audio;
	public static int status = 0;
	public static string soundText;
	public static int score = 0;

//	public int order;

	// Use this for initialization
	public static string EchoWord() {
		//StartCoroutine (TextToSpeech.DownloadTheAudio(status.ToString(), audio));
		//if (status==2) {
		//	string soundText = "The Word CAB is detected - You are right";

//		CATWordReco cwr = new CATWordReco ();

		if (TextToSpeech.level == 1) {

			if (CReco.detected == true && AReco.detected == true && TReco.detected == true) {//StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
				if ((CReco.position_X < AReco.position_X) && (AReco.position_X < TReco.position_X)) {
				soundText = "That’s correct.";
					score++;

				} else {
					soundText = "That's a good start, but wrong order.";
				}

				return soundText;
			} else {
				return "0";
			}
		}

		else if (TextToSpeech.level == 2) {

			if (DReco.detected == true && OReco.detected == true && GReco.detected == true) {//StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
				if ((DReco.position_X < OReco.position_X) && (OReco.position_X < GReco.position_X)) {
					soundText = "That’s correct.";
					score++;

				} else {
					soundText = "That's a good start, but wrong order.";
				}

				return soundText;
			} else {
				return "0";
			}
		}

		else if (TextToSpeech.level == 3) {

			if (CReco.detected == true && AReco.detected == true && RReco.detected == true) {//StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
				if ((CReco.position_X < AReco.position_X) && (AReco.position_X < RReco.position_X)) {
					soundText = "That’s correct.";
					score++;

				} else {
					soundText = "That's a good start, but wrong order.";
				}

				return soundText;
			} else {
				return "0";
			}
		}

		else if (TextToSpeech.level == 4) {

			if (SReco.detected == true && UReco.detected == true && NReco.detected == true) {//StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
				if ((SReco.position_X < UReco.position_X) && (UReco.position_X < NReco.position_X)) {
					soundText = "That’s correct.";
					score++;
				} else {
					soundText = "That's a good start, but wrong order.";
				}

				return soundText;
			} else {
				return "0";
			}
		}

		else if (TextToSpeech.level == 5) {

			if (CReco.detected == true && OReco.detected == true && WReco.detected == true) {//StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
				if ((CReco.position_X < OReco.position_X) && (OReco.position_X < WReco.position_X)) {
					soundText = "That’s correct.";
					score++;
				} else {
					soundText = "That's a good start, but wrong order.";
				}

				return soundText;
			} else {
				return "0";
			}
		}

		else if(TextToSpeech.level == 6) {

			if (RReco.detected == true && AReco.detected == true && IReco.detected == true && NReco.detected == true) {//StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
				if ((RReco.position_X < AReco.position_X) && (AReco.position_X < IReco.position_X) && (IReco.position_X < NReco.position_X)) {
					soundText = "That’s correct.";
					score++;
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

	public static void CheckWordStatus(){
		status++;

		//EchoWord ();
	}


	public static IEnumerator LoadNextPanel(){
	
		yield return new WaitForSeconds (2f);

		//TextToSpeech.level++;
		Debug.Log("LoadNExtPanel");
		Debug.Log (TextToSpeech.level);

		if (TextToSpeech.level == 1) {
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().DeactivateObjects ();
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().ActivateObject ("CatWordPanel");
		} 
		else if (TextToSpeech.level == 2)
		{
			Debug.Log ("DOgLoaded");
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().DeactivateObjects ();
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().ActivateObject ("DogWordPanel");
		}
		else if (TextToSpeech.level == 3)
		{
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().DeactivateObjects ();
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().ActivateObject ("CarWordPanel");
		}
		else if (TextToSpeech.level == 4)
		{
			Debug.Log ("SunPanel");
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().DeactivateObjects ();
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().ActivateObject ("SunWordPanel");
		}
		else if (TextToSpeech.level == 5)
		{
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().DeactivateObjects ();
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().ActivateObject ("CowWordPanel");
		}
		else if (TextToSpeech.level == 6)
		{
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().DeactivateObjects ();
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().ActivateObject ("RainWordPanel");
		}
		else if (TextToSpeech.level == 7)
		{
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().DeactivateObjects ();
			GameObject.Find ("Canvas").GetComponent<CanvasActivateObject> ().ActivateObject ("GameOver");
		}
	
	}

}
