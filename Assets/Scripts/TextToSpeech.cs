using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class TextToSpeech : MonoBehaviour {
	
	public AudioSource audio;
	public GameObject MainMenuPanel;

//	public InputField inputText;

	// Use this for initialization
	IEnumerator Start () {
		//ImageTargetPlayAudio boolVariable = new ImageTargetPlayAudio ();

		if (ImageTargetPlayAudio.CardDetected == false) {
			MainMenuPanel.SetActive (true);
			audio = gameObject.GetComponent<AudioSource> ();
			StartCoroutine (DownloadTheAudio ("Welcome to TactoPlus Speller Place the start card on the board when you are ready to start playing", audio));
			yield return new WaitForSeconds (7f);
			MainMenuPanel.SetActive (false);
			LoadScene (1);
		}
		//yeid new return;
		//return 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static IEnumerator DownloadTheAudio(string speechText, AudioSource _audio){

		Debug.Log("DownloadTHeAudio");

		//_audio = gameObject.GetComponent<AudioSource> ();

		Regex rgx = new Regex ("\\s+");

		string result = rgx.Replace (speechText, "+");

		string url = "http://api.voicerss.org/?key=fe2eefad18094d7fb1389274b60d3a74&hl=en-au&src="+result+"&c=MP3&f=16khz_8bit_stereo&r=2";
		Debug.Log(url);
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
