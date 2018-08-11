using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public int PlayerId;
	public float Velocity = 2f;
	private string _horizontalMoveAxisName;
	private string _verticalMoveAxisName;

	private Quaternion _rotation;
	private Vector3 _direction;
	
	readonly Vector3 baseRotation = Vector3.up;

	public GameObject UpShadow;
	public GameObject DownShadow;

	public CocktailColors CurrentColor = CocktailColors.None;

	void Start ()
	{
		_horizontalMoveAxisName = "Horizontal " + PlayerId;
		_verticalMoveAxisName = "Vertical " + PlayerId;
		GetPlayerRotationFromMovement(Vector3.up);
		UpdatePlayerRotation();
	}

	private bool CanCollectDrops()
	{
		return _direction == Vector3.down;
	}
	
	void Update () {
		var steer = new Vector3(Input.GetAxis(_horizontalMoveAxisName), Input.GetAxis(_verticalMoveAxisName));

		if (steer.sqrMagnitude > 1)
			steer = steer.normalized;

		GetComponent<Rigidbody>().velocity = steer * Time.deltaTime * Velocity;

		GetPlayerRotationFromMovement(steer);
		UpdatePlayerRotation();
	}

	private void UpdatePlayerRotation()
	{
		transform.localRotation = _rotation;
		UpShadow.GetComponent<Renderer>().enabled = false;
		DownShadow.GetComponent<Renderer>().enabled = false;

		if (_direction == Vector3.up)
		{
			UpShadow.GetComponent<Renderer>().enabled = true;
		}
		if (_direction == Vector3.down)
		{
			DownShadow.GetComponent<Renderer>().enabled = true;
		}
	}

	private void GetPlayerRotationFromMovement(Vector3 steer)
	{
		// majority axis == x
		if (Mathf.Abs(steer.x) > Mathf.Abs(steer.y))
		{
			if (steer.x > 0)
			{
				_direction = Vector3.right;
			}
			else if (steer.x < 0)
			{
				_direction = Vector3.left;
			}
		}
		// majority axis == y
		else
		{
			if (steer.y > 0)
			{
				_direction = Vector3.up;
			}
			else if (steer.y < 0)
			{
				_direction = Vector3.down;
			}			
		}
		_rotation = Quaternion.FromToRotation(baseRotation, _direction);

	}
}
