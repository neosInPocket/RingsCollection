using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSection : MonoBehaviour
{
	[SerializeField] private Image[] lifesPoints;
	[SerializeField] private Image[] speedPoints;
	[SerializeField] private Button lifesButton;
	[SerializeField] private Button speedButton;
	[SerializeField] private TMP_Text coinsText;

	private void Start()
	{
		RefreshShop();
	}

	private void RefreshShop()
	{
		CheckPoints(lifesPoints, SavesManager.MaxLifes);
		CheckPoints(speedPoints, SavesManager.RingVerticalSpeed);

		lifesButton.interactable = SavesManager.MaxLifes <= 3 && SavesManager.CurrentCoins >= 100;
		speedButton.interactable = SavesManager.RingVerticalSpeed <= 3 && SavesManager.CurrentCoins >= 40;
		coinsText.text = SavesManager.CurrentCoins.ToString();
	}

	public void BuyLifeUpgrade()
	{
		SavesManager.MaxLifes++;
		SavesManager.CurrentCoins -= 100;
		SavesManager.Save();

		RefreshShop();
	}

	public void BuySpeedUpgrade()
	{
		SavesManager.RingVerticalSpeed++;
		SavesManager.CurrentCoins -= 40;
		SavesManager.Save();

		RefreshShop();
	}

	private void CheckPoints(Image[] points, int value)
	{
		foreach (var point in points)
		{
			point.gameObject.SetActive(false);
		}

		for (int i = 0; i < value; i++)
		{
			points[i].enabled = true;
		}
	}
}
