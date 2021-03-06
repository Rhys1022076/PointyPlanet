using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [FMODUnity.EventRef]
	public string Event;

	public bool PlayOnAwake;
	public bool PlayOnDestroy;

	private void Start()
	{
		if (PlayOnAwake)
		{
			PlayOneShot();
		}
	}

	public void PlaySound(string path)
	{
        FMODUnity.RuntimeManager.PlayOneShot(path, gameObject.GetComponent<Transform>().position);
	}

	public void PlayOneShot()
	{
		FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
	}

	private void OnDestroy()
	{
		if (PlayOnDestroy)
		{
			PlayOneShot();
		}
	}
}
