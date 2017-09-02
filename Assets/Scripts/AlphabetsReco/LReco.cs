using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class LReco : MonoBehaviour,ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;

	public static bool detected = false;
	private ImageTargetBehaviour mImageTargetBehaviour = null;
	public static float position_X;

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
		AudioSource audio = gameObject.GetComponent<AudioSource> ();

		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{

			Vector2 targetSize = mImageTargetBehaviour.GetSize();
			float targetAspect = targetSize.x / targetSize.y;

			Vector3 pointOnTarget = new Vector3(-0.5f, 0, -0.5f/targetAspect); 

			Vector3 targetPointInWorldRef = transform.TransformPoint(pointOnTarget);

			Vector3 screenPoint = Camera.main.WorldToScreenPoint(targetPointInWorldRef);

			position_X = screenPoint.x;

			detected = true;

			if (CATWordReco.EchoWord () != "0")
			{
				StartCoroutine (TextToSpeech.DownloadTheAudio (CATWordReco.EchoWord (), audio));
				TextToSpeech.level++;
				StartCoroutine (CATWordReco.LoadNextPanel());
			}

		}
		else
		{
			detected = false;
			audio.Stop();
		}
	}   
}