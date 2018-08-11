using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGraphics : MonoBehaviour
{
	public GameObject RedCube;
	public GameObject OrangeCube;
	public GameObject YellowCube;
	public GameObject GreenCube;
	public GameObject BlueCube;
	public GameObject PurpleCube;

	public GameObject GetByColor(CocktailColors color)
	{
		var dict = new Dictionary<CocktailColors, GameObject>
		{
			{CocktailColors.Blue, BlueCube},
			{CocktailColors.Green, GreenCube },
			{CocktailColors.Orange, OrangeCube},
			{CocktailColors.Purple, PurpleCube},
			{CocktailColors.Red, RedCube},
			{CocktailColors.Yellow, YellowCube}
		};
		return dict[color];
	}
}
