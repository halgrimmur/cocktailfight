using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
	public MeshFilter SpawnBounds;

	public int MaxCubes;
	private float lastSpawn;
	public float MinSpawnDelay = 1f;
	
	// Use this for initialization
	void Start ()
	{
		lastSpawn = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Spawn();
	}

	Vector3 PickPosition()
	{
		var numVertices = SpawnBounds.mesh.vertexCount;
		return 		SpawnBounds.transform.TransformPoint(SpawnBounds.mesh.vertices[Random.Range(0, numVertices - 1)])
			;
	}

	void Spawn()
	{
		var allCubes = FindObjectsOfType<IceCube>();
		if (allCubes.Length < MaxCubes && Time.realtimeSinceStartup > lastSpawn + MinSpawnDelay)
		{
			var pos = PickPosition();
			var clr = RandomColor();
			var prefab = Pallettes.Instance.CubeGraphics.GetByColor(clr);
			Instantiate(prefab, pos, Quaternion.identity);
			lastSpawn = Time.realtimeSinceStartup;
		}
	}

	CocktailColors RandomColor()
	{
		var clrs = new CocktailColors[]
		{
			CocktailColors.Blue, CocktailColors.Red, CocktailColors.Yellow,
			CocktailColors.Blue, CocktailColors.Red, CocktailColors.Yellow,
			//CocktailColors.Blue, CocktailColors.Red, CocktailColors.Yellow,
			CocktailColors.Green, CocktailColors.Orange, CocktailColors.Purple
		};
		var rndm = clrs[
			Random.Range(0, clrs.Length)];
		Debug.Log(rndm);
		return rndm;
	}
	
}
