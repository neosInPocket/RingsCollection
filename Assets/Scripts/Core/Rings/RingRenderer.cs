using System.Collections;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class RingRenderer : MonoBehaviour
{
	[SerializeField] private MeshRenderer meshRenderer;
	[SerializeField] private Material[] materials;
	[SerializeField] private float dissolveSpeed;
	private Material currentMaterial;

	private void On()
	{
		SetRandomMaterial();
		StopAllCoroutines();
		StartCoroutine(Dissolve(false));
	}

	private void SetRandomMaterial()
	{
		Material material = materials[Random.Range(0, materials.Length)];
		meshRenderer.material = material;
		currentMaterial = material;
	}

	public AvaliableColors GetCurrentColor()
	{
		return (AvaliableColors)(int)currentMaterial.GetFloat("_ColorIndex");
	}

	public void Destroy()
	{
		StopAllCoroutines();
		StartCoroutine(Dissolve(true));
	}

	private IEnumerator Dissolve(bool reverse)
	{
		var currentDissolveValue = currentMaterial.GetFloat("_Dissolve");
		float targetValue = 0;

		if (!reverse)
		{
			targetValue = 1;
			while (currentDissolveValue < 1)
			{
				currentDissolveValue += dissolveSpeed * Time.deltaTime;
				currentMaterial.SetFloat("_Dissolve", currentDissolveValue);
				yield return new WaitForEndOfFrame();
			}
		}
		else
		{
			while (currentDissolveValue > 0)
			{
				currentDissolveValue -= dissolveSpeed * Time.deltaTime;
				currentMaterial.SetFloat("_Dissolve", currentDissolveValue);
				yield return new WaitForEndOfFrame();
			}
		}

		currentMaterial.SetFloat("_Dissolve", targetValue);
		if (reverse)
		{
			gameObject.SetActive(false);
		}
	}
}
