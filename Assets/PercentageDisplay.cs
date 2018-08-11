using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageDisplay : MonoBehaviour
{
	public Text RedPercent;
	public Text BluePercent;
	public Text YellowPercent;

	public void UpdatePercent(float red, float blue, float yellow)
	{
		RedPercent.text = Mathf.RoundToInt(100 * red) + "%";
		BluePercent.text = Mathf.RoundToInt(100 * blue) + "%";
		YellowPercent.text = Mathf.RoundToInt(100 * yellow) + "%";
	}
	
}
