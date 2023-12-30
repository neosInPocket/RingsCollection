using UnityEngine;

public class Timer : MonoBehaviour
{
	public float timeLimit = 60f; // The time limit for the timer
	private float timeLeft; // The time left on the timer
	private bool isRunning = false; // Whether the timer is currently running

	void Start()
	{
		timeLeft = timeLimit;
		isRunning = true;
	}

	void Update()
	{
		if (isRunning)
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0f)
			{
				isRunning = false;
				timeLeft = 0f;
				Debug.Log("Time's up!");
			}
		}
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 36;
		style.normal.textColor = Color.white;

		GUI.Label(new Rect(10, 10, 200, 50), "Time: " + Mathf.FloorToInt(timeLeft), style);
	}
}