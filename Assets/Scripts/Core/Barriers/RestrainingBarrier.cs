using UnityEngine;

public class RestrainingBarrier : MonoBehaviour
{
	[SerializeField] private BoxCollider boxCollider;
	[SerializeField] private float barrierWidth;
	[SerializeField] private float barrierDepth;
	[SerializeField] private int position;

	private Vector3 screenSize;

	private void Start()
	{
		screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10f));
		screenSize.x = Mathf.Abs(screenSize.x);
		screenSize.y = Mathf.Abs(screenSize.y);
		screenSize.z = 0;
		SetPosition();
	}

	private void SetPosition()
	{
		transform.position = new Vector3(position * (screenSize.x + barrierWidth / 2), 0);
		boxCollider.size = new Vector3(barrierWidth, 2 * screenSize.y, barrierDepth);
	}
}
