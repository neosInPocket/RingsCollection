using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
	[SerializeField] private List<GameObject> screens;
	[SerializeField] private GameObject startScreen;
	[SerializeField] private float fadeSpeed;
	[SerializeField] private float fadeSpeedTreshold;
	[SerializeField] private Material material;

	private GameObject currentScreen;

	private void Start()
	{
		currentScreen = startScreen;
		material.SetFloat("_Dissolve", -0.2f);
	}

	public void Fade(GameObject screen)
	{
		StopAllCoroutines();
		StartCoroutine(FadeEffect(screen));
	}

	public void Fade()
	{
		StopAllCoroutines();
		StartCoroutine(FadeGameEffect());
	}

	private IEnumerator FadeEffect(GameObject screen)
	{
		material.SetFloat("_Dissolve", -0.2f);
		var currentDissolve = -0.2f;
		var distance = 1.2f - currentDissolve;

		while (currentDissolve < 1.2f)
		{
			distance = 1.2f - currentDissolve;
			currentDissolve += fadeSpeed * Time.deltaTime * (distance + fadeSpeedTreshold);
			material.SetFloat("_Dissolve", currentDissolve);
			yield return null;
		}

		currentDissolve = 1.2f;
		material.SetFloat("_Dissolve", currentDissolve);
		material.SetFloat("_Direction", -1);

		currentScreen.SetActive(false);
		currentScreen = screen;
		screen.SetActive(true);

		material.SetFloat("_Dissolve", -0.2f);
		distance = Mathf.Abs(-0.2f - currentDissolve);

		while (currentDissolve > -0.2f)
		{
			distance = Mathf.Abs(-0.2f - currentDissolve);
			currentDissolve -= fadeSpeed * Time.deltaTime * (distance + fadeSpeedTreshold);
			material.SetFloat("_Dissolve", currentDissolve);
			yield return null;
		}

		material.SetFloat("_Dissolve", -0.2f);
		material.SetFloat("_Direction", 1);
	}

	private IEnumerator FadeGameEffect()
	{
		material.SetFloat("_Dissolve", -0.2f);
		var currentDissolve = -0.2f;
		var distance = 1.2f - currentDissolve;

		while (currentDissolve < 1.2f)
		{
			distance = 1.2f - currentDissolve;
			currentDissolve += fadeSpeed * Time.deltaTime * (distance + fadeSpeedTreshold);
			material.SetFloat("_Dissolve", currentDissolve);
			yield return null;
		}

		currentDissolve = 1.2f;
		material.SetFloat("_Dissolve", currentDissolve);

		if (SavesManager.FirstGamePassed == 0)
		{
			SavesManager.FirstGamePassed = 1;
			SavesManager.Save();
			SceneManager.LoadScene("TutorialScene");
		}
		else
		{
			SceneManager.LoadScene("MainRingsScene");
		}
	}

}
