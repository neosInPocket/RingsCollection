using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class RingPushHandler : MonoBehaviour
{
	[SerializeField] private float pushForce;
	[SerializeField] private float sphereCastRadius;
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		Touch.onFingerDown += OnFingerDown;
	}

	private void OnFingerDown(Finger finger)
	{
		var screenPosition = GameTools.ScreenToWorldPoint(finger.screenPosition);

		var sphereCast = Physics.OverlapSphere(screenPosition, sphereCastRadius);
		foreach (var collider in sphereCast)
		{
			if (collider.gameObject.TryGetComponent<RingMovementController>(out RingMovementController ring))
			{
				var radiusVector = collider.transform.position - screenPosition;
				var magnitude = radiusVector.magnitude;
				var direction = radiusVector.normalized;
				ring.PushInDirection(direction * pushForce / magnitude, screenPosition);
			}
		}
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= OnFingerDown;
	}
}
