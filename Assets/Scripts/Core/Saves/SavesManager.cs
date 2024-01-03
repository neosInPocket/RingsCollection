using UnityEngine;

public class SavesManager : MonoBehaviour
{
	public static int Level;
	public static int MaxLifes;
	public static int RingVerticalSpeed;
	public static int FirstGamePassed;
	public static int SkinIndex;
	public static int CurrentCoins;
	public static float MusicValue;
	public static float SFXValue;


	[SerializeField] private bool defaults;

	private void Awake()
	{
		if (defaults)
		{
			ClearData();
		}

		Load();
	}


	public static void Save()
	{
		PlayerPrefs.SetInt("Level", Level);
		PlayerPrefs.SetInt("MaxLifes", MaxLifes);
		PlayerPrefs.SetInt("RingVerticalSpeed", RingVerticalSpeed);
		PlayerPrefs.SetInt("FirstGamePassed", FirstGamePassed);
		PlayerPrefs.SetInt("SkinIndex", SkinIndex);
		PlayerPrefs.SetInt("CurrentCoins", CurrentCoins);
		PlayerPrefs.SetFloat("MusicValue", MusicValue);
		PlayerPrefs.SetFloat("SFXValue", SFXValue);

		PlayerPrefs.Save();
	}

	public static void Load()
	{
		Level = PlayerPrefs.GetInt("Level", 1);
		MaxLifes = PlayerPrefs.GetInt("MaxLifes", 1);
		RingVerticalSpeed = PlayerPrefs.GetInt("RingVerticalSpeed", 0);
		FirstGamePassed = PlayerPrefs.GetInt("FirstGamePassed", 0);
		SkinIndex = PlayerPrefs.GetInt("SkinIndex", 0);
		CurrentCoins = PlayerPrefs.GetInt("CurrentCoins", 40);
		MusicValue = PlayerPrefs.GetFloat("MusicValue", 1f);
		SFXValue = PlayerPrefs.GetFloat("SFXValue", 1f);
	}

	private static void ClearData()
	{
		Level = 1;
		MaxLifes = 1;
		RingVerticalSpeed = 0;
		FirstGamePassed = 0;
		SkinIndex = 0;
		CurrentCoins = 40;
		MusicValue = 1f;
		SFXValue = 1f;

		Save();
	}
}
