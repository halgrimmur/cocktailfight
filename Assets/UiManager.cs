using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	public WinScreen WinScreen;

	void Start()
	{
		SoundManager.Instance.PlayBackgroundMusic();
	}
	
	public void ShowWinScreen(string player)
	{
		WinScreen.gameObject.SetActive(true);
		WinScreen.ShowWinScreen(player);
	}
}
