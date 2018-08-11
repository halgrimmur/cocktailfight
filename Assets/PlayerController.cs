using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public int PlayerId;
	private string _hAxisName;
	private string _vAxisName;
	
	// Use this for initialization
	void Start ()
	{
		_hAxisName = "Horizontal " + PlayerId;
		_vAxisName = "Vertical " + PlayerId;
	}
	
	// Update is called once per frame
	void Update () {
		var steer = new Vector3(Input.GetAxis(_hAxisName), Input.GetAxis(_vAxisName));
		Debug.Log(steer);
	}
}
