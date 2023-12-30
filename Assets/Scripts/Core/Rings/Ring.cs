using UnityEngine;

public class Ring : MonoBehaviour
{
	[SerializeField] private RingRenderer ringRenderer;
	public AvaliableColors CurrentColor => ringRenderer.GetCurrentColor();
	public bool Dead => ringRenderer.Dead;
	public void Enable() => ringRenderer.Enable();
	public void Destroy() => ringRenderer.Destroy();
}
