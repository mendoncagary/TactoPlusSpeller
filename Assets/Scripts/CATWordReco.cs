using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CATWordReco : MonoBehaviour {

	public static AudioSource audio;
	public static int status = 0;

	// Use this for initialization
	public static string EchoWord() {



		//StartCoroutine (TextToSpeech.DownloadTheAudio(status.ToString(), audio));
		//if (status==2) {
			
			string soundText = "The Word CAB is detected - You are right";

		

		if (AReco.ADetected == true && BReco.BDetected == true) {//StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
			return soundText;
		} else
		{
			return "0";
		}
		//}
		
	}

	public static void CheckWordStatus(){
		status++;

		//EchoWord ();
	}
}
