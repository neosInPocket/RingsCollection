using System;
using UnityEngine;

public class Ring : MonoBehaviour
{
	[SerializeField] private RingRenderer ringRenderer;
	public AvaliableColors CurrentColor => ringRenderer.GetCurrentColor();
	public bool Dead => ringRenderer.Dead;
	public Action<Ring> Destroyed { get; set; }
	public void Enable() => ringRenderer.Enable();
	public void Destroy()
	{
		Destroyed?.Invoke(this);
		ringRenderer.Destroy();
	}
}
