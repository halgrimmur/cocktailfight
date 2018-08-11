using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocktailColorSetter : MonoBehaviour
{
	public Color Blue;
	public Color Red;
	public Color Yellow;
	public Color Green;
	public Color Orange;
	public Color Purple;

	public PercentageDisplay PercentageDisplay;
	
	public List<CocktailColors> CaughtDroplets;

	void Awake()
	{
		CaughtDroplets = new List<CocktailColors>();
	}
	
	public void CatchDroplet(CocktailColors color)
	{
		CaughtDroplets.Add(color);
		UpdateColor();
		SoundManager.Instance.CatchSound();
		UpdatePercentages();
	}

	void UpdatePercentages()
	{
		float red = 0;
		float blue = 0;
		float yellow = 0;
		foreach (var droplet in CaughtDroplets)
		{
			if (droplet == CocktailColors.Blue)
				blue += 1;
			if (droplet == CocktailColors.Red)
				red += 1;
			if (droplet == CocktailColors.Yellow)
				yellow += 1;
		}

		PercentageDisplay.UpdatePercent(red / CaughtDroplets.Count, blue / CaughtDroplets.Count,
			yellow / CaughtDroplets.Count);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Droplet>() != null)
		{
			Destroy(other.gameObject);
			CatchDroplet(other.GetComponent<Droplet>().Color);
		}
	}

	void UpdateColor()
	{
		var avgColor = Color.black;
		foreach (var droplet in CaughtDroplets)
		{
			avgColor += Color.white - ToColor(droplet);
		}

		avgColor = Color.white - (avgColor / CaughtDroplets.Count);

		GetComponent<Renderer>().material.color = avgColor;
	}

	Color ToColor(CocktailColors clr)
	{
		if (clr==CocktailColors.Blue)
			return Blue;
		else if (clr==CocktailColors.Green)
			return Green;
		else if (clr==CocktailColors.Yellow)
			return Yellow;
		else if (clr==CocktailColors.Orange)
			return Orange;
		else if (clr==CocktailColors.Red)
			return Red;
		else if (clr==CocktailColors.Purple)
			return Purple;
		return Color.black;
	}
}
