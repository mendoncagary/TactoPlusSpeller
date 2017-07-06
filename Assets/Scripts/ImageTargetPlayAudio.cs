using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class ImageTargetPlayAudio : MonoBehaviour,ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;

	public AudioSource audio;
	public static bool CardDetected = false;
	public GameObject StartCardObject;
	//public GameObject MainMenuPanel;
	//public GameObject CatWordPanel;
	//public GameObject Canvas = GameObject.Find("Canvas");


	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		audio = gameObject.GetComponent<AudioSource> ();

		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			// Play audio when target is found
			//audio.Play();
			string soundText = "Start card detected";
			//TextToSpeech tts = new TextToSpeech ();
			StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));
			//StartCoroutine (Delay());
			//StartCardObject.SetActive (false);
			//yield return new WaitForSeconds (4f);
			Invoke("Delay",4);



		}
		else
		{
			// Stop audio when target is lost

			//audio.Stop();
		}
	}   

	public void Delay(){
		TextToSpeech tts = new TextToSpeech ();

		//CatWordPanel = Canvas.transform.Find ("CatWordPanel");
		//MainMenuPanel = Canvas.transform.Find ("MainMenuPanel");

		//MainMenuPanel.SetActive (false);
		//CatWordPanel.SetActive (true);

		CardDetected = true;

		tts.LoadScene (0);
	}
}