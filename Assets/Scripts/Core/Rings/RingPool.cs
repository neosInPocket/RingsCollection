using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class RingPool : MonoBehaviour
{
	[SerializeField] private List<Ring> defaultRings;
	[SerializeField] private Ring prefab;
	private List<Ring> rings;

	private void Awake()
	{
		rings = defaultRings;
	}

	public Ring Instantiate(Vector3 position, Vector3 angles)
	{
		Ring freeRing = rings.FirstOrDefault(x => !x.gameObject.activeSelf);
		if (freeRing != null)
		{
			freeRing.gameObject.SetActive(true);
			freeRing.transform.position = position;
			freeRing.transform.eulerAngles = angles;
			return freeRing;
		}
		else
		{
			var instance = Instantiate(prefab, position, Quaternion.Euler(angles), transform);
			instance.transform.position = position;
			instance.transform.eulerAngles = angles;
			rings.Add(instance);
			return instance;
		}
	}

	public Ring InstantiateRandomRotation(Vector3 position)
	{
		var randomX = Random.Range(0, 360f);
		var randomY = Random.Range(0, 360f);
		var randomZ = Random.Range(0, 360f);
		return Instantiate(position, new Vector3(randomX, randomY, randomZ));
	}
}
