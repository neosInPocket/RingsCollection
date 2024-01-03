using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
	[SerializeField] private StandController[] stands;
	[SerializeField] private int scoreValue;
	private int maxScore;
	private int currentScore;
	private int currentHealth;
	public Action<int> CurrentScoreChanged;
	public Action<int> CurrentHealthChanged;
	public Action MaxScoreReached;
	public Action Dead;
	public int MaxScore => maxScore;


	private void Start()
	{
		foreach (var stand in stands)
		{
			stand.RingScored += OnRingScored;
			stand.ColorDismatch += OnColorDismatch;
		}

		currentScore = 0;
		currentHealth = SavesManager.MaxLifes;
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

	private void OnColorDismatch()
	{
		currentHealth--;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Dead?.Invoke();
		}

		CurrentHealthChanged?.Invoke(currentHealth);
	}

	private void OnDestroy()
	{
		foreach (var stand in stands)
		{
			if (stand != null)
				stand.ColorDismatch -= OnRingScored;
		}
	}

	public int GetMaxScoreValue()
	{
		return (int)(12 * Mathf.Log(Mathf.Sqrt(SavesManager.Level) + 1));
	}

	public int LevelRewardCoins()
	{
		return (int)(12 * Mathf.Log(Mathf.Pow(SavesManager.Level, 2) + 1) + 11);
	}
}
