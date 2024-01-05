using System;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TutorialHandler : MonoBehaviour
{
	[SerializeField] private TutorialSpawner tutorialSpawner;
	[SerializeField] private RingPushHandler ringPushHandler;
	[SerializeField] private string[] characterTexts;
	[SerializeField] private TMP_Text text;
	[SerializeField] private GameObject tutorialPanel;
	[SerializeField] private TMP_Text goalText;
	[SerializeField] private GameObject levitatingBall;
	private int currentPhase;
	private Func<bool> nextPhase;

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		Touch.onFingerDown += OnNext;

		currentPhase = 0;
		nextPhase = PlayPhase;
	}

	public void OnNext(Finger finger)
	{
		if (nextPhase())
		{
			currentPhase++;
			return;
		}

		if (currentPhase >= characterTexts.Length)
		{
			FinalPhase();
			return;
		}

		text.text = characterTexts[currentPhase];
		currentPhase++;
	}

	private bool PlayPhase()
	{
		if (currentPhase != 2)
		{
			return false;
		}

		Touch.onFingerDown -= OnNext;
		ringPushHandler.Enable();
		tutorialPanel.SetActive(false);
		levitatingBall.SetActive(false);
		tutorialSpawner.ProgressReached += Phase;
		tutorialSpawner.RingPassed += OnRingPassed;
		tutorialSpawner.Spawn();
		goalText.gameObject.SetActive(true);
		goalText.text = "0/2";
		return true;
	}

	private void OnRingPassed(int progress)
	{
		goalText.text = $"{progress}/2";
	}

	private void Phase()
	{
		text.text = characterTexts[currentPhase - 1];
		tutorialSpawner.ProgressReached -= Phase;
		tutorialSpawner.RingPassed -= OnRingPassed;
		nextPhase();
		ringPushHandler.Disable();
		tutorialSpawner.Clear();
		tutorialPanel.SetActive(true);
		levitatingBall.SetActive(true);
		goalText.gameObject.SetActive(false);
		Touch.onFingerDown += OnNext;
	}

	private void FinalPhase()
	{
		SceneManager.LoadScene("MainRingsScene");
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= OnNext;
	}


}
