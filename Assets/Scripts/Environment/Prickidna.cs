using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prickidna : MonoBehaviour
{
	// reference to animator component
	private Animator anim;

	private void Start()
	{
		// get animator component on child gameobject (in this case the model)
		// necessary to animate children of the model
		anim = GetComponentInChildren<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		// if the gameobject which enters the trigger has the 'bullet' tag
		// to add the crusher and slicer tags to this statement, swap the comment below
		//if (other.CompareTag("Bullet") || other.CompareTag("Blade") || other.CompareTag("Crusher"))
		if (other.CompareTag("Bullet"))
		{
			//destroy the bullet
			Destroy(other.gameObject);

			// start death functionality
			StartCoroutine(Death());
		}
	}

	// death functionality
	IEnumerator Death()
	{
		// trigger animation
		anim.SetTrigger("Death");

		// wait for 1 second to allow the animation to play
		yield return new WaitForSeconds(1f);

		// destroy prickidna object
		Destroy(gameObject);
	}
}
