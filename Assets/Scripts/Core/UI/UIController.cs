using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private ScoreHandler scoreHandler;
	[SerializeField] private ProgressBar progressBar;
	[SerializeField] private ProgressBar healthBar;
	[SerializeField] private TMP_Text currentLevel;

	private void Start()
	{
		scoreHandler.CurrentScoreChanged += CurrentScoreChanged;
		scoreHandler.MaxScoreReached += MaxScoreReached;
		scoreHandler.CurrentHealthChanged += HealthChanged;
		progressBar.FillAmount = 0f;
		healthBar.FillAmount = (float)SavesManager.MaxLifes / 3f;
		currentLevel.text = $"LEVEL {SavesManager.Level}";
	}

	private void CurrentScoreChanged(int value)
	{
		progressBar.Fill((float)value / (float)scoreHandler.MaxScore);
	}

	private void MaxScoreReached()
	{
		progressBar.Fill(1f);
	}

	private void HealthChanged(int value)
	{
		healthBar.Fill((float)value / 3f);
		Debug.Log(value);
	}

	private void OnDestroy()
	{
		scoreHandler.CurrentScoreChanged -= CurrentScoreChanged;
		scoreHandler.MaxScoreReached -= MaxScoreReached;
		scoreHandler.CurrentHealthChanged -= HealthChanged;
	}
}
