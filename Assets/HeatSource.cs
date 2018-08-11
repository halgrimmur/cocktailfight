using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSource : MonoBehaviour
{

	public float MeltingTime;

	private void ApplyHeatToIcecubes()
	{
		var icecubes = FindObjectsOfType<IceCube>();
		foreach (var icecube in icecubes)
		{
			if (icecube.IsIlluminated)
			{
				icecube.Icyness -= Time.deltaTime / MeltingTime;
			}
		}
	}
	
	void Update () {
		ApplyHeatToIcecubes();
	}
}
