using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
	public Text WinText;

	public void ShowWinScreen(string player)
	{
		WinText.text = player + " Won!";
	}

	public void Restart()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
}
