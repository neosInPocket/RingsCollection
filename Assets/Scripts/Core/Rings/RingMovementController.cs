using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;
using Unity.VisualScripting;
using TMPro;

public class RingMovementController : MonoBehaviour
{
	[SerializeField] Rigidbody rigid;
	[SerializeField] private Vector3 normalRotation;
	[SerializeField] private float maxRotationSpeed;
	[SerializeField] private float yAcceleration;
	[SerializeField] private float xAcceleration;
	[SerializeField] private float maxVerticalSpeed;
	[SerializeField] private float angleTreshold;
	[SerializeField] private float pushRotatingSpeed;
	private bool isBeingPushed;

	private void Start()
	{
		GameTools.ScreenSize();
	}

	private void Update()
	{
		SetNormalHorizontalVelocity();
		SetNormalVerticalVelocity();
	}

	private float LerpNormalRotation(Vector2 target, float speed)
	{
		//rigid.angularVelocity = Vector3.zero;
		var currentDirection = target;
		var direction = new Vector3(currentDirection.x, currentDirection.y, 0);
		var angle = Vector2.Angle(direction, transform.forward);
		var deltaPhi = speed * NormalDistribution(angle, angleTreshold) * Time.deltaTime;
		Debug.Log(deltaPhi);

		var crossProduct = Vector3.Cross(transform.forward, direction);
		var cross = crossProduct.z;
		var rotationMultiplier = (int)(cross / Mathf.Abs(cross));
		deltaPhi *= rotationMultiplier;

		var a11 = Mathf.Cos(deltaPhi);
		var a12 = -Mathf.Sin(deltaPhi);
		var a21 = Mathf.Sin(deltaPhi);
		var a22 = Mathf.Cos(deltaPhi);

		transform.forward = new Vector2(a11 * transform.forward.x + a12 * transform.forward.y, a21 * transform.forward.x + a22 * transform.forward.y);
		return angle;
	}

	private void SetNormalHorizontalVelocity()
	{
		Vector3 velocity = rigid.velocity;

		if (Mathf.Abs(rigid.velocity.x) > 0)
		{
			if (rigid.velocity.x > 0)
			{
				velocity.x -= xAcceleration * Time.deltaTime;
			}

			if (rigid.velocity.x < 0)
			{
				velocity.x += xAcceleration * Time.deltaTime;
			}
		}

		rigid.velocity = velocity;
	}

	private void SetNormalVerticalVelocity()
	{
		Vector3 velocity = rigid.velocity;

		if (rigid.velocity.y < -maxVerticalSpeed)
		{
			velocity.y += yAcceleration * Time.deltaTime;
		}

		if (rigid.velocity.y > -maxVerticalSpeed)
		{
			velocity.y -= yAcceleration * Time.deltaTime;
		}

		rigid.velocity = velocity;
	}

	public void PushInDirection(Vector3 force, Vector3 origin)
	{
		StopAllCoroutines();
		StartCoroutine(RotateNormalDirection(origin));
		rigid.velocity += force;
	}

	private IEnumerator RotateNormalDirection(Vector3 target)
	{
		isBeingPushed = true;
		float angle = 0;
		if (target.y > transform.position.y)
		{
			target = transform.position - target;
		}

		angle = LerpNormalRotation(target, pushRotatingSpeed);

		while (angle > angleTreshold)
		{
			angle = LerpNormalRotation(target, pushRotatingSpeed);

			yield return new WaitForEndOfFrame();
		}

		isBeingPushed = false;
	}

	private float NormalDistribution(float x, float threshold)
	{
		return (1 - threshold) * Mathf.Exp(-(Mathf.Pow(x - 90f, 2) / 50f)) + threshold;
	}
}
