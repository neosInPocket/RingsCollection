using System;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
	[SerializeField] private StandController[] stands;
	[SerializeField] private float scoreValue;
	private float maxScore;
	private float currentScore;
	public Action<float> CurrentScoreChanged;
	public Action MaxScoreReached;


	private void Start()
	{
		foreach (var stand in stands)
		{
			stand.OnRingScored += OnRingScored;
		}

		currentScore = 0;
		maxScore = GetMaxScoreValue();
	}

	private void OnRingScored()
	{
		currentScore += scoreValue;
		if (currentScore >= maxScore)
		{
			currentScore = maxScore;
			MaxScoreReached?.Invoke();
		}

		CurrentScoreChanged?.Invoke(currentScore);
	}

	private void OnDestroy()
	{
		foreach (var stand in stands)
		{
			if (stand != null)
				stand.OnRingScored -= OnRingScored;
		}
	}

	public float GetMaxScoreValue()
	{
		return 10;
	}
}
