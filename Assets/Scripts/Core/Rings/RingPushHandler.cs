using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class RingPushHandler : Toggleable
{
	[SerializeField] private float pushForce;
	[SerializeField] private float sphereCastRadius;
	[SerializeField] private float thresholdMagnitude;
	[SerializeField] private DestroyableEffect[] effects;
	private bool isEnabled;


	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		Touch.onFingerDown += OnFingerDown;
	}

	private void OnFingerDown(Finger finger)
	{
		if (!isEnabled) return;

		var screenPosition = GameTools.ScreenToWorldPoint(finger.screenPosition);

		bool isReady = effects[SavesManager.SkinIndex].PlayEffect(screenPosition);
		if (!isReady) return;

		var sphereCast = Physics.OverlapSphere(screenPosition, sphereCastRadius);
		foreach (var collider in sphereCast)
		{
			if (collider.gameObject.TryGetComponent<RingMovementController>(out RingMovementController ring))
			{
				var radiusVector = collider.transform.position - screenPosition;
				var magnitude = radiusVector.magnitude;
				if (magnitude < thresholdMagnitude)
				{
					magnitude = thresholdMagnitude;
				}

				var direction = radiusVector.normalized;
				ring.PushInDirection(direction * pushForce / magnitude, screenPosition);
			}
		}
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= OnFingerDown;
	}

	public override void Enable()
	{
		isEnabled = true;
	}

	public override void Disable()
	{
		isEnabled = false;
	}
}
