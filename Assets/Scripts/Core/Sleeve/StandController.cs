using UnityEngine;

public class StandController : MonoBehaviour
{
	[SerializeField] private RingSleeveRenderer ringSleeveRenderer;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.TryGetComponent<Ring>(out Ring ring))
		{
			if (ring.Dead) return;

			var circleEq = Mathf.Pow(ring.transform.position.x - ringSleeveRenderer.StandPosition.x, 2) + Mathf.Pow(ring.transform.position.z - ringSleeveRenderer.StandPosition.z, 2);

			if (circleEq < Mathf.Pow(ringSleeveRenderer.SleeveRadius, 2))
			{
				Debug.Log("Point");
			}
			else
			{
				Debug.Log("NO POINT");
			}

			ring.Destroy();
		}
	}
}
