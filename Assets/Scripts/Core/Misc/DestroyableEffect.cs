using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableEffect : MonoBehaviour
{
	[SerializeField] private float duration;
	private bool isPlaying;

	public bool PlayEffect(Vector3 position)
	{
		if (isPlaying)
		{
			return false;
		}

		gameObject.SetActive(true);
		StartCoroutine(Effect(position));
		return true;
	}

	private IEnumerator Effect(Vector3 position)
	{
		isPlaying = true;
		transform.position = position;
		yield return new WaitForSeconds(duration);
		isPlaying = false;
		gameObject.SetActive(false);
	}
}
