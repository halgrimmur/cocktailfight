using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{	
	public static DropSpawner Instance { get; private set; }
	
	void Start ()
	{
		Instance = this;
	}

	public void SpawnDrop(Vector3 position, CocktailColors color)
	{
		Instantiate(Pallettes.Instance.DropletGraphics.GetByColor(color), position, Quaternion.identity);
	}	
}
