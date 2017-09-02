using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

//	public AudioClip clip;
	Text txt;


	// Use this for initialization
	IEnumerator Start () {
		AudioSource audio = gameObject.GetComponent<AudioSource> ();

		txt = GameObject.Find ("Score").GetComponent<Text> ();

		txt.text = "Score:"+CATWordReco.score.ToString()+"/6";
		//gameObject.transform.GetChild(1).gameObject.GetComponent<TextEditor>() = CATWordReco.score;
		StartCoroutine (TextToSpeech.DownloadTheAudio("The game is over.",audio));

		yield return new WaitForSeconds(4f);

		//audio.clip = clip;

		//audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);

		StartCoroutine (TextToSpeech.DownloadTheAudio("You scored "+CATWordReco.score+" out of 6. Keep learning and try again.",audio));
		yield return new WaitForSeconds(5f);


		StartCoroutine (TextToSpeech.DownloadTheAudio("The Game will restart.",audio));
		yield return new WaitForSeconds(9f);

		//TextToSpeech tts = new TextToSpeech ();
		//tts.LoadScene (2);

	}

	// Update is called once per frame
	void Update () {
		
	}



}
