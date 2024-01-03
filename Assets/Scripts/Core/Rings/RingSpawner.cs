using System.Collections;
using UnityEngine;

public class RingSpawner : Toggleable
{
	[SerializeField] private RingPool pool;
	[SerializeField] private Vector2 xSpawnRange;
	[Range(0, 1f)]
	[SerializeField] private float ySpawnPosition;
	[SerializeField] private float zSpawnPosition;
	[SerializeField] private Vector2 spawnDelayRange;
	private Vector2 screenSize;
	private bool isEnabled;
	private bool isSpawning;

	private void Start()
	{
		screenSize = GameTools.ScreenSize();
	}

	private void Update()
	{
		if (!isEnabled) return;
		if (isSpawning) return;

		StartCoroutine(Spawn());
	}

	public void Toggle(bool enabled)
	{
		isEnabled = enabled;
	}

	public IEnumerator Spawn()
	{
		isSpawning = true;

		var randomX = Random.Range(2 * xSpawnRange.x * screenSize.x - screenSize.x, 2 * xSpawnRange.y * screenSize.x - screenSize.x);
		var y = 2 * ySpawnPosition * screenSize.y - screenSize.y;

		Vector3 randomPosition = new Vector3(randomX, y, zSpawnPosition);
		pool.InstantiateRandomRotation(randomPosition);
		yield return new WaitForSeconds(Random.Range(spawnDelayRange.x, spawnDelayRange.y));
		isSpawning = false;
	}

	public override void Enable()
	{
		isEnabled = true;
		isSpawning = false;
	}

	public override void Disable()
	{
		isEnabled = false;
		isSpawning = false;
	}

	public void Clear()
	{
		pool.Clear();
	}
}
