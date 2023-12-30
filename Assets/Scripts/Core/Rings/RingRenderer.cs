using UnityEngine;

public class RingRenderer : MonoBehaviour
{
	[SerializeField] private MeshRenderer meshRenderer;
	[SerializeField] private Material[] materials;
	private Material currentMaterial;

	private void OnEnable()
	{
		SetRandomMaterial();
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
}
