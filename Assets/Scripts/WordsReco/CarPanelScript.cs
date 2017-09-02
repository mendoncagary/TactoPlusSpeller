﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPanelScript : MonoBehaviour {

	AudioSource audio;
	public AudioClip clip;
	public float timeLeft = 120.0f;
	bool tenTimer = false;
	bool twentyTimer = false;
	bool thirtyTimer = false;
	bool levelOver = false;


	IEnumerator Start () {
		audio = gameObject.GetComponent<AudioSource> ();

		StartCoroutine (TextToSpeech.DownloadTheAudio("Here's your next clue.",audio));

		yield return new WaitForSeconds(4f);

		audio.clip = clip;

		audio.Play ();

		yield return new WaitForSeconds(audio.clip.length);

		StartCoroutine (TextToSpeech.DownloadTheAudio("It's a 3 letter word",audio));
		yield return new WaitForSeconds(5f);

		StartCoroutine (TextToSpeech.DownloadTheAudio("A modern vehicle that runs on petrol or diesel. We can drive around the city in it.",audio));
		yield return new WaitForSeconds(9f);

	}

	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 60.0f) {
			Debug.Log ("60 seconds left");
			if (!thirtyTimer) {
				thirtyTimer = true;
				StartCoroutine (TextToSpeech.DownloadTheAudio ("Your are running out of time. 30 seconds left.", audio));
			}

		}
		if (timeLeft <= 30.0f) {
			Debug.Log ("30 seconds left");
			if (!twentyTimer) {
				twentyTimer = true;
				StartCoroutine (TextToSpeech.DownloadTheAudio ("20 seconds left.", audio));
			}
		}
		if (timeLeft <= 10.0f) {
			Debug.Log ("10 seconds left");
			if (!tenTimer) {
				tenTimer = true;
				StartCoroutine (TextToSpeech.DownloadTheAudio ("10 seconds left.", audio));
			}

		}

		if (timeLeft <= 0.0f) {
			Debug.Log ("LevelOver");
			if (!levelOver)
			{
				levelOver = true;
				Debug.Log ("CarPanel-if level over");
				LevelOver ();
			}
		}
			
	}



	void LevelOver(){
		Debug.Log ("Function Level Over");
		TextToSpeech.level++;
		Debug.Log ("Car Panel"+TextToSpeech.level);
		StartCoroutine(CATWordReco.LoadNextPanel ());

	}


}
