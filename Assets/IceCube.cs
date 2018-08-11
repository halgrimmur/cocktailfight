using System.Collections;
using System.Collections.Generic;
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
		// TODO add rules for which colors ice turn into which colors drops
		DropSpawner.Instance.SpawnDrop(transform.position, Color);
		Destroy(gameObject);
	}

	public void SetGraphic(int smeltIndex)
	{
		var bla = Pallettes.Instance.CubeGraphics.GetByColor(Color);
		Graphic.sprite = bla.GetComponent<IndividualCubePalette>().MeltingStates[smeltIndex];
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<UmbrellaShadow>() != null)
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
