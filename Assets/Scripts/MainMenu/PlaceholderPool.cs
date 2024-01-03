using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceholderPool : MonoBehaviour
{
	// [SerializeField] private List<RingMovementController> defaultRings;
	// [SerializeField] private RingMovementController prefab;
	// [SerializeField] private float spawnDelay;
	// [SerializeField] private float zSpawnPosition;
	// private List<RingMovementController> rings;
	// private bool isSpawning;

	// private void Awake()
	// {
	// 	rings = defaultRings;
	// }

	// private void Update()
	// {
	// 	if (isSpawning) return;

	// 	StartCoroutine(SpawnRing());
	// }

	// private IEnumerator SpawnRing()
	// {
	// 	var position = new Vector3();
	// 	Instantiate()
	// }

	// public RingMovementController Instantiate(Vector3 position, Vector3 angles)
	// {
	// 	RingMovementController freeRing = rings.FirstOrDefault(x => !x.gameObject.activeSelf);
	// 	if (freeRing != null)
	// 	{
	// 		freeRing.transform.position = position;
	// 		freeRing.transform.eulerAngles = angles;
	// 		return freeRing;
	// 	}
	// 	else
	// 	{
	// 		var instance = Instantiate(prefab, position, Quaternion.Euler(angles), transform);
	// 		instance.transform.position = position;
	// 		instance.transform.eulerAngles = angles;
	// 		rings.Add(instance);
	// 		return instance;
	// 	}
	// }

	// public RingMovementController InstantiateRandomRotation(Vector3 position)
	// {
	// 	var randomX = Random.Range(0, 360f);
	// 	var randomY = Random.Range(0, 360f);
	// 	var randomZ = Random.Range(0, 360f);
	// 	return Instantiate(position, new Vector3(randomX, randomY, randomZ));
	// }

	// public void Clear()
	// {
	// 	foreach (var ring in rings)
	// 	{
	// 		ring.gameObject.SetActive(false);
	// 	}
	// }
}
