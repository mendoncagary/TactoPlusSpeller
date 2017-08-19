using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class BReco : MonoBehaviour,ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;

	public AudioSource audio;
	public static bool BDetected = false;
	public GameObject BCard;
	//public GameObject MainMenuPanel;
	//public GameObject CatWordPanel;
	//public GameObject Canvas = GameObject.Find("Canvas");
	private ImageTargetBehaviour mImageTargetBehaviour = null;
	public static float BWord_X;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		mImageTargetBehaviour = GetComponent<ImageTargetBehaviour>();

		if (mImageTargetBehaviour == null)
		{
			Debug.Log ("ImageTargetBehaviour not found ");
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
			Vector2 targetSize = mImageTargetBehaviour.GetSize();
			float targetAspect = targetSize.x / targetSize.y;

			// We define a point in the target local reference 
			// we take the bottom-left corner of the target, 
			// just as an example
			// Note: the target reference plane in Unity is X-Z, 
			// while Y is the normal direction to the target plane
			Vector3 pointOnTarget = new Vector3(-0.5f, 0, -0.5f/targetAspect); 

			// We convert the local point to world coordinates
			Vector3 targetPointInWorldRef = transform.TransformPoint(pointOnTarget);

			// We project the world coordinates to screen coords (pixels)
			Vector3 screenPoint = Camera.main.WorldToScreenPoint(targetPointInWorldRef);

			Debug.Log ("target point in screen coords: " + screenPoint.x + ", " + screenPoint.y);
			//StartCoroutine (TextToSpeech.DownloadTheAudio("target point in screen coords: " + screenPoint.x + ", " + screenPoint.y, audio));

			BWord_X = screenPoint.y;

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

			BDetected = true;

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
			//StartCoroutine (TextToSpeech.DownloadTheAudio(CATWordReco.EchoWord(), audio));
			//wordScript.EchoWord ();
			//tts.LoadScene (0);


		}
		else
		{
			BDetected = false;
			CATWordReco.status=2;
			// Stop audio when target is lost

			audio.Stop();
		}
	}   
}
