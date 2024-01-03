using System.Linq;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
	[SerializeField] private AudioSource music;

	private void Awake()
	{
		var controller = GameObject.FindGameObjectsWithTag("MusicController");

		var otherController = controller.FirstOrDefault(x => x != gameObject);
		if (otherController != null)
		{
			Destroy(otherController);
		}

		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		music.volume = SavesManager.MusicValue;
	}

	public void ChangeMusicVolume(float value)
	{
		music.volume = value;
		SavesManager.MusicValue = value;
	}

	public void ChangeSFXVolume(float value)
	{
		SavesManager.SFXValue = value;
	}

	public void ApplyChanges()
	{
		SavesManager.Save();
	}
}
