using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletGraphics : MonoBehaviour
{

	public GameObject RedDroplet;
	public GameObject YellowDroplet;
	public GameObject BlueDroplet;
	
	
	public GameObject GetByColor(CocktailColors color)
	{
		var dict = new Dictionary<CocktailColors, GameObject>
		{
			{CocktailColors.Blue, BlueDroplet},
			{CocktailColors.Red, RedDroplet},
			{CocktailColors.Yellow, YellowDroplet}
		};
		return dict[color];
	}
}
