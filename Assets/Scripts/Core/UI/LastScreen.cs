using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScreen : MonoBehaviour
{
	[SerializeField] private TMP_Text resultText;
	[SerializeField] private TMP_Text earnedText;
	[SerializeField] private TMP_Text continueButtonText;

	public void PlayScreen(bool win, int earned = 0)
	{
		gameObject.SetActive(true);

		string result = default;
		string buttonText = default;

		if (win)
		{
			result = "WIN!!";
			buttonText = "NEXT LEVEL";
		}
		else
		{
			result = "LOSE..";
			buttonText = "TRY AGAIN";
		}

		resultText.text = result;
		continueButtonText.text = buttonText;
		earnedText.text = earned.ToString();
	}

	public void ReplayLevel()
	{
		SceneManager.LoadScene("MainRingsScene");
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
