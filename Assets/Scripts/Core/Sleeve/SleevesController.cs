using System.Collections.Generic;
using UnityEngine;

public class SleevesController : MonoBehaviour
{
	[SerializeField] private RingSleeve[] sleeves;
	[SerializeField] private List<Material> currentMaterials;
	[SerializeField] private Vector2 xRange;
	[Range(0, 1f)]
	[SerializeField] private float yPosition;
	[SerializeField] private float zPosition;
	[SerializeField] private float sleeveHeight;
	[SerializeField] private float standHeight;
	private Vector2 screenSize;

	private void Start()
	{
		screenSize = GameTools.ScreenSize();
		SetRandomColors();
		SetPositions();
	}

	private void SetRandomColors()
	{
		var list = Shuffle(currentMaterials);

		for (int i = 0; i < sleeves.Length; i++)
		{
			sleeves[i].ChangeMaterial(list[i]);
		}
	}

	private void SetPositions()
	{
		float xLeftPosition = 2 * screenSize.x * xRange.x - screenSize.x;
		float xRightPosition = 2 * screenSize.x * xRange.y - screenSize.x;
		float step = (xRightPosition - xLeftPosition) / 2;
		float currentXPosition = xLeftPosition;
		float currentYPosition = 2 * screenSize.y * yPosition - screenSize.y + sleeveHeight + standHeight;

		for (int i = 0; i < sleeves.Length; i++)
		{
			sleeves[i].transform.position = new Vector3(currentXPosition, currentYPosition, zPosition);
			currentXPosition += step;
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
