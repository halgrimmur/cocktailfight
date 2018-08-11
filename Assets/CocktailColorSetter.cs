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

	public GameObject CocktailLiquid;

	public int MaxDroplets = 50;
	
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
		SetFillingPercent((float)CaughtDroplets.Count / MaxDroplets);
	}

	public void SetFillingPercent(float p)
	{
		var sc = CocktailLiquid.transform.localScale;
		sc.x = Mathf.Lerp(0.1f, 1.09f, p);
		CocktailLiquid.transform.localScale = sc;
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
