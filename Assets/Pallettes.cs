using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallettes : MonoBehaviour
{
	public static Pallettes Instance { get; private set; }
	public CubeGraphics CubeGraphics;
	public DropletGraphics DropletGraphics;

	void Awake()
	{
		Instance = this;
	}
}
