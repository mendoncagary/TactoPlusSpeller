using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPanelScript : MonoBehaviour {

	public AudioSource audio;

	public AudioClip clipCat;


	// Use this for initialization
	IEnumerator Start () {
		audio = gameObject.GetComponent<AudioSource> ();
		StartCoroutine (TextToSpeech.DownloadTheAudio("Guess the animal",audio));

	//	yield return new WaitForSeconds(4f);

		audio.clip = clipCat;

		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);

		StartCoroutine (TextToSpeech.DownloadTheAudio("3 letter word",audio));
		yield return new WaitForSeconds(3f);

		StartCoroutine (TextToSpeech.DownloadTheAudio("Soft furry animal that likes fish and milk",audio));
		yield return new WaitForSeconds(5f);

		TextToSpeech tts = new TextToSpeech ();
		tts.LoadScene (2);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
