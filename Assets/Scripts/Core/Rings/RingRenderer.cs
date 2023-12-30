using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RingRenderer : MonoBehaviour
{
	[SerializeField] private MeshRenderer meshRenderer;
	[SerializeField] private Material[] materials;
	[SerializeField] private float dissolveSpeed;
	private Material currentMaterial;
	private SphereCollider[] colliders;
	public bool Dead { get; set; }

	private void Awake()
	{
		colliders = GetComponents<SphereCollider>();
	}

	public void Enable()
	{
		gameObject.SetActive(true);
		EnableColliders(true);
		SetRandomMaterial();
		StartCoroutine(Dissolve(false));
	}

	private void SetRandomMaterial()
	{
		Material material = materials[Random.Range(0, materials.Length)];
		meshRenderer.material = new Material(material);
		currentMaterial = meshRenderer.material;
	}

	public AvaliableColors GetCurrentColor()
	{
		return (AvaliableColors)(int)currentMaterial.GetFloat("_ColorIndex");
	}

	public void Destroy()
	{
		StopAllCoroutines();
		StartCoroutine(Dissolve(true));
		EnableColliders(false);
	}

	private IEnumerator Dissolve(bool reverse)
	{
		Dead = reverse;

		float currentDissolveValue = 0;
		float targetValue = 0;

		if (reverse)
		{
			Dead = true;
			currentMaterial.SetFloat("_Dissolve", 0);
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
			currentMaterial.SetFloat("_Dissolve", 1);
			currentDissolveValue = 1;

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

	private void EnableColliders(bool value)
	{
		foreach (var collider in colliders)
		{
			collider.enabled = value;
		}
	}
}
