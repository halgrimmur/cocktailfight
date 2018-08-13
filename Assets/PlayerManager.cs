using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public GameObject[] Players;

	private CubeManager _cubeManager;

	private int _playerCount;

	public GameObject HintUi;
	
	void Start()
	{
		foreach (var player in Players)
		{
			player.SetActive(false);
		}

		_cubeManager = FindObjectOfType<CubeManager>();
		_cubeManager.gameObject.SetActive(false);
	}
	
	void Update () {
		for (int i = 0; i < Players.Length; i++)
		{
			if (!Players[i].activeInHierarchy && Check(i))
			{
				Players[i].SetActive(true);
				_playerCount += 1;
				Debug.Log(_playerCount);
			}
		}
		
		if (!_cubeManager.gameObject.activeInHierarchy && _playerCount > 1)
		{
			_cubeManager.gameObject.SetActive(true);
			HintUi.SetActive(false);
		}

	}

	bool Check(int i)
	{
		if (Mathf.Abs(Input.GetAxis("Horizontal " + (i+1))) > 0.5f ||
		    Mathf.Abs(Input.GetAxis("Vertical " + (i+1))) > 0.5f)
		{
			return true;
		}

		return false;
	}
}
