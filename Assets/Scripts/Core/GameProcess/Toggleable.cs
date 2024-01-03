using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public abstract class Toggleable : MonoBehaviour
{
	public abstract void Enable();
	public abstract void Disable();
}
