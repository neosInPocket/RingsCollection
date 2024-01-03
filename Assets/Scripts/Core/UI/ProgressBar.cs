using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private float fillSpeed;
	[SerializeField] private float speedThreshold;
	[SerializeField] private string dissolveKey;
	public float FillAmount
	{
		get => material.GetFloat(dissolveKey);
		set => material.SetFloat(dissolveKey, value);
	}
	private Material material;

	private void Awake()
	{
		material = image.material;
	}


	public void Fill(float amount)
	{
		StopAllCoroutines();
		StartCoroutine(FillFade(amount));
	}

	private IEnumerator FillFade(float target)
	{
		var currentFill = material.GetFloat(dissolveKey);
		var distance = target - currentFill;
		int direction = (int)(distance / Mathf.Abs(distance));

		while ((currentFill < target && direction > 0) || (currentFill > target && direction < 0))
		{
			currentFill += direction * fillSpeed * Time.deltaTime * (Mathf.Abs(distance) + speedThreshold);
			distance = target - currentFill;

			material.SetFloat(dissolveKey, currentFill);
			yield return new WaitForEndOfFrame();
		}

		material.SetFloat(dissolveKey, target);
	}
}
