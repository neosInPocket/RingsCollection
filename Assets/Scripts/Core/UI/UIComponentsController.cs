using Unity.VisualScripting;
using UnityEngine;

public class UIComponentsController : MonoBehaviour
{
	[SerializeField] private ScoreHandler scoreHandler;
	[SerializeField] private CountDown countDown;
	[SerializeField] private RingPushHandler ringPushHandler;
	[SerializeField] private RingSpawner spawner;
	[SerializeField] private LastScreen lastScreen;

	private void Start()
	{
		scoreHandler.Dead += Dead;
		scoreHandler.MaxScoreReached += MaxScoreReached;
		countDown.PlayCount(OnPlayCountEnd);
	}

	private void OnPlayCountEnd()
	{
		Enable();
	}

	private void Dead()
	{
		DisableAll();

		lastScreen.PlayScreen(false);
	}

	private void MaxScoreReached()
	{
		DisableAll();
		SavesManager.CurrentCoins += scoreHandler.LevelRewardCoins();
		SavesManager.Level++;
		SavesManager.Save();

		lastScreen.PlayScreen(true, scoreHandler.LevelRewardCoins());
	}

	private void OnDestroy()
	{
		scoreHandler.Dead -= Dead;
	}

	private void DisableAll()
	{
		spawner.Toggle(false);
		ringPushHandler.Disable();
		spawner.Clear();
	}

	private void Enable()
	{
		spawner.Toggle(true);
		ringPushHandler.Enable();
	}
}
