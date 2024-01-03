using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TutorialSpawner : MonoBehaviour
{
	[SerializeField] private RingPool pool;
	[SerializeField] private Vector2 xSpawnRange;
	[Range(0, 1f)]
	[SerializeField] private float ySpawnPosition;
	[SerializeField] private float zSpawnPosition;
	[SerializeField] private Vector2 spawnDelayRange;
	private Vector2 screenSize;
	private int currentProgress;
	public Action ProgressReached;
	public Action<int> RingPassed;

	private void Start()
	{
		screenSize = GameTools.ScreenSize();
		currentProgress = 0;
	}

	public void Spawn()
	{
		currentProgress++;

		var randomX = Random.Range(2 * xSpawnRange.x * screenSize.x - screenSize.x, 2 * xSpawnRange.y * screenSize.x - screenSize.x);
		var y = 2 * ySpawnPosition * screenSize.y - screenSize.y;

		Vector3 randomPosition = new Vector3(randomX, y, zSpawnPosition);

		var ring = pool.InstantiateRandomRotation(randomPosition);
		ring.Destroyed += OnRingDestroyed;
	}

	private void OnRingDestroyed(Ring ring)
	{
		ring.Destroyed -= OnRingDestroyed;
		RingPassed?.Invoke(currentProgress);

		if (currentProgress >= 2)
		{
			ProgressReached?.Invoke();
			return;
		}

		Spawn();
	}

	public void Clear()
	{
		pool.Clear();
	}
}
