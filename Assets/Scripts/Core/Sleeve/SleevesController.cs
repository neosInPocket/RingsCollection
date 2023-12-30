using System.Collections.Generic;
using UnityEngine;

public class SleevesController : MonoBehaviour
{
	[SerializeField] private RingSleeve[] sleeves;
	[SerializeField] private List<Material> currentMaterials;

	private void Start()
	{
		SetRandomColors();
	}

	private void SetRandomColors()
	{
		var list = Shuffle(currentMaterials);

		for (int i = 0; i < sleeves.Length; i++)
		{
			sleeves[i].ChangeMaterial(list[i]);
		}
	}

	private List<Material> Shuffle(List<Material> materials)
	{
		var list = materials;

		for (int i = 0; i < materials.Count; i++)
		{
			var randomIndex = Random.Range(0, list.Count);
			var temp = list[i];
			list[i] = materials[randomIndex];
			list[randomIndex] = temp;
		}

		return list;
	}
}
