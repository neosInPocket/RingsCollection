using UnityEngine;

public class Ring : MonoBehaviour
{
	[SerializeField] private RingRenderer ringRenderer;

	public AvaliableColors CurrentColor => ringRenderer.GetCurrentColor();
}
