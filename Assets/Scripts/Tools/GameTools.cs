using System.Linq;
using UnityEngine;

public static class GameTools
{
	public static Vector2 ScreenSize()
	{
		return ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
	}

	public static Vector3 ScreenToWorldPoint(Vector2 screenPosition)
	{
		var ray = Camera.main.ScreenPointToRay(screenPosition);

		var rayDirection = ray.direction;
		var rayOrigin = ray.origin;

		Vector3 planeNormal = new Vector3(0, 0, 1);
		Vector3 planePoint = new Vector3(0, 0, 0);

		float dotProduct = Vector3.Dot(rayDirection, planeNormal);

		float distance = Vector3.Dot(planePoint - rayOrigin, planeNormal) / dotProduct;

		Vector3 intersectionPoint = rayOrigin + distance * rayDirection;
		return intersectionPoint;
	}
}
