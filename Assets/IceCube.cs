using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IceCube : MonoBehaviour
{
	public float Icyness = 1;
	public bool IsIlluminated = true;
	public CocktailColors Color;
	public SpriteRenderer Graphic;

	private int _smeltGraphicIndex;

	public int SmeltGraphicIndex
	{
		get { return _smeltGraphicIndex; }
		set
		{
			if (value != _smeltGraphicIndex)
			{
				_smeltGraphicIndex = value; 
				if (value >= 0 && value < 4)
					SetGraphic(value);				
			}
		}
	}

	void Update()
	{
		if (Icyness < 0)
		{
			Melt();
		}

		SmeltGraphicIndex = Mathf.RoundToInt((1-Icyness) / 0.25f);
		UpdateIllumination();
	}

	void Start()
	{
		SetGraphic(0);
	}

	void Melt()
	{
		if (Color == CocktailColors.Blue || Color == CocktailColors.Red || Color == CocktailColors.Yellow)
			DropSpawner.Instance.SpawnDrop(transform.position, Color);
		else if (Color == CocktailColors.Green)
		{
			DropSpawner.Instance.SpawnDrop(transform.position - Vector3.left*0.4f, CocktailColors.Blue);
			DropSpawner.Instance.SpawnDrop(transform.position + Vector3.left*0.4f, CocktailColors.Yellow);
		}
		else if (Color == CocktailColors.Orange)
		{
			DropSpawner.Instance.SpawnDrop(transform.position - Vector3.left*0.4f, CocktailColors.Red);
			DropSpawner.Instance.SpawnDrop(transform.position + Vector3.left*0.4f, CocktailColors.Yellow);
			
		}
		else if (Color == CocktailColors.Purple)
		{
			DropSpawner.Instance.SpawnDrop(transform.position - Vector3.left*0.4f, CocktailColors.Blue);
			DropSpawner.Instance.SpawnDrop(transform.position + Vector3.left*0.4f, CocktailColors.Red);			
		}
		Destroy(gameObject);
		
		SoundManager.Instance.MeltingSound();
	}

	public void SetGraphic(int smeltIndex)
	{
		var bla = Pallettes.Instance.CubeGraphics.GetByColor(Color);
		Graphic.sprite = bla.GetComponent<IndividualCubePalette>().MeltingStates[smeltIndex];
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<UmbrellaShadow>() != null &&
		    other.gameObject.GetComponent<UmbrellaShadow>().enabled)
		{
			IsIlluminated = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<UmbrellaShadow>() != null)
		{
			IsIlluminated = true;
		}
	}

	private void UpdateIllumination()
	{
		if (IsIlluminated)
		{
			Graphic.color = UnityEngine.Color.white;
		}
		else {
			Graphic.color = UnityEngine.Color.gray;
		}
	}
}
