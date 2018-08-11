using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
	public GameObject DropPrefab;
	
	public static DropSpawner Instance { get; private set; }
	
	// Use this for initialization
	void Start ()
	{
		Instance = this;
	}


	public void SpawnDrop(Vector3 position, CocktailColors color)
	{
		var newDrop = Instantiate(DropPrefab, position, Quaternion.identity);
		// TODO set drop's color
	}
	
	
}
