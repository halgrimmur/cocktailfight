using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

	public UiManager UiManager;
	public string PlayerName;

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

		if (CaughtDroplets.Count == MaxDroplets)
		{
			var allGlasses = FindObjectsOfType<CocktailColorSetter>();
			var dict = new Dictionary<string, float>();
			foreach (var glass in allGlasses)
			{
				var totalCount = glass.CaughtDroplets.Count;
				var redCount = glass.CaughtDroplets.Count(x => x == CocktailColors.Red);
				float percentage = 0;
				if (totalCount!=0)
					percentage = (float)redCount / totalCount;
				dict.Add(glass.PlayerName, percentage);
			}

			var maxPercentage = dict.Values.Max();
			foreach (var glass in dict)
			{
				if (glass.Value == maxPercentage)
				{
					FindObjectOfType<CubeManager>().gameObject.SetActive(false);
					foreach (var iceCube in FindObjectsOfType<IceCube>())
					{
						Destroy(iceCube.gameObject);
					}
					foreach (var iceCube in FindObjectsOfType<Droplet>())
					{
						Destroy(iceCube.gameObject);
					}
					UiManager.ShowWinScreen(glass.Key);
					return;
				}
			}
		}
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
		var avgColor = GetSubtractiveAverageColor(CaughtDroplets.Select(ToColor).ToList());

		GetComponent<Renderer>().material.color = avgColor;
	}

	Color GetSubtractiveAverageColor(List<Color> colors)
	{
		var invertedColorSum = Color.black;
		foreach (var color in colors)
		{
			invertedColorSum += Color.white - color;
		}

		return Color.white - invertedColorSum / colors.Count;
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
