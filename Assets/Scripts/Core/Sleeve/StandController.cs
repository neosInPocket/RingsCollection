using System;
using UnityEngine;

public class StandController : MonoBehaviour
{
	[SerializeField] private RingSleeveRenderer ringSleeveRenderer;
	public Action RingScored { get; set; }
	public Action ColorDismatch { get; set; }


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.TryGetComponent<Ring>(out Ring ring))
		{
			if (ring.Dead) return;

			if (ring.CurrentColor == ringSleeveRenderer.CurrentColor)
			{
				var circleEq =
				Mathf.Pow(ring.transform.position.x - ringSleeveRenderer.StandPosition.x, 2) +
				Mathf.Pow(ring.transform.position.z - ringSleeveRenderer.StandPosition.z, 2);

				if (circleEq < Mathf.Pow(ringSleeveRenderer.SleeveRadius, 2))
				{
					RingScored?.Invoke();
				}
				else
				{
					ColorDismatch?.Invoke();
				}
			}
			else
			{
				ColorDismatch?.Invoke();
			}

			ring.Destroy();
		}
	}
}
