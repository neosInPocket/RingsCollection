using UnityEngine;
using UnityEngine.UI;

public class SettingsSection : MonoBehaviour
{
	[SerializeField] private Slider musicSlider;
	[SerializeField] private Slider sfxSlider;
	private SoundsController soundsController;

	private void Start()
	{
		var soundsControllerGO = GameObject.FindGameObjectWithTag("MusicController");
		soundsController = soundsControllerGO.GetComponent<SoundsController>();


		musicSlider.value = SavesManager.MusicValue;
		sfxSlider.value = SavesManager.SFXValue;
	}

	public void ChangeMusicVolume(float value)
	{
		soundsController.ChangeMusicVolume(value);
	}

	public void ChangeSFXVolume(float value)
	{
		soundsController.ChangeSFXVolume(value);
	}

	public void ApplyChanges()
	{
		soundsController.ApplyChanges();
	}
}
