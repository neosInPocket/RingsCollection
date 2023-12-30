using UnityEngine;

public class RingSleeveRenderer : MonoBehaviour
{
	[SerializeField] private MeshRenderer stand;
	[SerializeField] private MeshRenderer sleeve;

	public void ChangeMaterial(Material material)
	{
		sleeve.material = material;
		stand.material = material;
	}
}
