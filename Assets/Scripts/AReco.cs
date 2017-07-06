using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class AReco : MonoBehaviour,ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;

	public AudioSource audio;
	public static bool ADetected = false;
	public GameObject ACard;
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
			//string soundText = "A word detected";
			//TextToSpeech tts = new TextToSpeech ();
			//	StartCoroutine (TextToSpeech.DownloadTheAudio(soundText, audio));

			//StartCardObject.SetActive (false);
			//yield return new WaitForSeconds (4f);

			//TextToSpeech tts = new TextToSpeech ();

			//CatWordPanel = Canvas.transform.Find ("CatWordPanel");
			//MainMenuPanel = Canvas.transform.Find ("MainMenuPanel");

			//MainMenuPanel.SetActive (false);
			//CatWordPanel.SetActive (true);

			ADetected = true;

			//GameObject ARCamera = GameObject.Find("ARCamera");
			//CATWordReco wordScript = ARCamera.GetComponent<CATWordReco>();
			CATWordReco.status=2;
			//wordScript.status;
			//StartCoroutine (TextToSpeech.DownloadTheAudio(CATWordReco.status.ToString(), audio));

			//CATWordReco cwr = new CATWordReco ();

			if (CATWordReco.EchoWord () != "0")
			{
				StartCoroutine (TextToSpeech.DownloadTheAudio (CATWordReco.EchoWord (), audio));
			}
			//wordScript.EchoWord ();
			//tts.LoadScene (0);


		}
		else
		{
			ADetected = false;
			CATWordReco.status=2;
			// Stop audio when target is lost

			audio.Stop();
		}
	}   
}
