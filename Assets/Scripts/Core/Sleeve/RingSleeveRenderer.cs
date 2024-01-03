using UnityEngine;

public class RingSleeveRenderer : MonoBehaviour
{
	[SerializeField] private MeshRenderer stand;
	[SerializeField] private MeshRenderer sleeve;
	[SerializeField] private Renderer cylinder;
	public float SleeveRadius => cylinder.bounds.size.x / 2;
	public Vector3 StandPosition => stand.transform.position;
	public AvaliableColors CurrentColor => (AvaliableColors)(int)sleeve.material.GetFloat("_ColorIndex");

	public void ChangeMaterial(Material material)
	{
		sleeve.material = material;
	}
}
