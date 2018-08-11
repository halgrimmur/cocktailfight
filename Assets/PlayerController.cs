using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public int PlayerId;
	public float Velocity = 2f;
	private string _horizontalMoveAxisName;
	private string _verticalMoveAxisName;
	
	void Start ()
	{
		_horizontalMoveAxisName = "Horizontal " + PlayerId;
		_verticalMoveAxisName = "Vertical " + PlayerId;
	}
	
	void Update () {
		var steer = new Vector3(Input.GetAxis(_horizontalMoveAxisName), Input.GetAxis(_verticalMoveAxisName));
		Debug.Log(steer);
		if (steer.sqrMagnitude > 1)
			steer = steer.normalized;
		transform.position += steer*Time.deltaTime*Velocity;
	}
}
