using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class TextToSpeech : MonoBehaviour {
	
	public AudioSource audio;
	//
	//public GameObject MainMenuPanel;
	public static int level = 0;
	//public GameObject ImageC;
	private ActivateImageTarget activateimagetarget;
//	public InputField inputText;
	public AudioClip gameIntro;

	// Use this for initialization
	IEnumerator Start () {
		//ImageTargetPlayAudio boolVariable = new ImageTargetPlayAudio ();

		//if (ImageTargetPlayAudio.CardDetected == false) {
			//MainMenuPanel.SetActive (true);
		//CanvasActivateObject.ActivateObject(0);
			//cao.ActivateObject (0);	
		GameObject.Find ("Canvas").GetComponent<CanvasActivateObject>().ActivateObject("MainMenuPanel");

			audio = gameObject.GetComponent<AudioSource> ();

		audio.clip = gameIntro;
		audio.Play ();
		yield return new WaitForSeconds (audio.clip.length);

			StartCoroutine (DownloadTheAudio ("Welcome to Tactopus spelling game! Show us what a good speller you are.", audio));
			yield return new WaitForSeconds (10f);
		StartCoroutine (DownloadTheAudio ("In this game, you can listen to clues and spell out words with your braille alphabet cards. Now clear the board, and when you’re ready to start, find the play button on the right side of the board and hold it for 5 seconds..", audio));
			//MainMenuPanel.SetActive (false);
		yield return new WaitForSeconds (17f);
			//LoadScene (1);
//		activateimagetarget = new ActivateImageTarget();
		level++;
		GameObject.Find ("Canvas").GetComponent<CanvasActivateObject>().DeactivateObjects();
		GameObject.Find ("Canvas").GetComponent<CanvasActivateObject>().ActivateObject("CatWordPanel");
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().DeactivateImageTargets();
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().ActivateTarget("ImageA");
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().ActivateTarget("ImageT");
		//GameObject.Find ("ARCamera").GetComponent<ActivateImageTarget>().ActivateTarget("ImageC");

			

		//StartCoroutine(ActivateImageTarget.DeactivateImageTargets ());
			//ActivateImageTarget.ActivateImagetarget (ImageC);


		//}
		//yeid new return;
		//return 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static IEnumerator DownloadTheAudio(string speechText, AudioSource _audio){

//		Debug.Log("DownloadTHeAudio");

		//_audio = gameObject.GetComponent<AudioSource> ();

		Regex rgx = new Regex ("\\s+");

		string result = rgx.Replace (speechText, "+");

		string url = "http://api.voicerss.org/?key=b5f062c2562e44bb86a3b4725942074a&hl=en-gb&src="+result+"&c=MP3&f=16khz_8bit_stereo&r=0";
//		Debug.Log(url);
		WWW www = new WWW (url);
		yield return www;

		_audio.clip = www.GetAudioClip (false, true, AudioType.MPEG);
		_audio.Play ();
		//yield return new WaitForSeconds(_audio.clip.length);

	}

	/*public void ButtonOnClick(){
		StartCoroutine (DownloadTheAudio());
	}*/

	public void LoadScene(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

}
