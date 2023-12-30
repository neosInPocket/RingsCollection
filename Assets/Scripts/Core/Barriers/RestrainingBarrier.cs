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
		screenSize = GameTools.ScreenSize();
		SetPosition();
	}

	private void SetPosition()
	{
		transform.position = new Vector3(position * (screenSize.x + barrierWidth / 2), 0);
		boxCollider.size = new Vector3(barrierWidth, 15 * screenSize.y, barrierDepth);
	}
}
