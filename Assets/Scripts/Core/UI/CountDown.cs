using System;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
	[SerializeField] private TMP_Text cdText;
	[SerializeField] private Animator animator;
	[SerializeField] private string[] texts;
	private Action EndMethod { get; set; }
	private int currentIndex;

	public void PlayCount(Action endAction)
	{
		gameObject.SetActive(true);
		EndMethod = endAction;

		currentIndex = 1;
		cdText.text = texts[0];
	}

	public void NextPhase()
	{
		if (currentIndex >= texts.Length)
		{
			OnEnd();
			return;
		}

		cdText.text = texts[currentIndex];
		currentIndex++;

		animator.SetTrigger("Next");
	}

	private void OnEnd()
	{
		EndMethod();
		gameObject.SetActive(false);
	}
}
