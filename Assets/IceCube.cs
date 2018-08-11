using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{
	public float Icyness = 1;
	public bool IsIlluminated = true;
	public CocktailColors Color;

	void Update()
	{
		if (Icyness < 0)
		{
			Melt();
		}
	}

	void Melt()
	{
		// TODO add rules for which colors ice turn into which colors drops
		DropSpawner.Instance.SpawnDrop(transform.position, Color);
		Destroy(gameObject);
	}
}
