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
	readonly Vector3 baseRotation = Vector3.up;

	public CocktailColors CurrentColor = CocktailColors.None;

	void Start ()
	{
		_horizontalMoveAxisName = "Horizontal " + PlayerId;
		_verticalMoveAxisName = "Vertical " + PlayerId;		
	}

	private bool CanCollectDrops()
	{
		return _rotation == Quaternion.FromToRotation(baseRotation, Vector3.down);
	}
	
	void Update () {
		var steer = new Vector3(Input.GetAxis(_horizontalMoveAxisName), Input.GetAxis(_verticalMoveAxisName));

		if (steer.sqrMagnitude > 1)
			steer = steer.normalized;

		GetComponent<Rigidbody>().velocity = steer * Time.deltaTime * Velocity;

		//GetPlayerRotationFromButtonPress();
		GetPlayerRotationFromMovement(steer);
		transform.localRotation = _rotation;

	}

	private void GetPlayerRotationFromMovement(Vector3 steer)
	{
		// majority axis == x
		if (Mathf.Abs(steer.x) > Mathf.Abs(steer.y))
		{
			if (steer.x > 0)
			{
				_rotation = Quaternion.FromToRotation(baseRotation, Vector3.right);
			}
			else if (steer.x < 0)
			{
				_rotation = Quaternion.FromToRotation(baseRotation, Vector3.left);
			}
		}
		// majority axis == y
		else
		{
			if (steer.y > 0)
			{
				_rotation = Quaternion.FromToRotation(baseRotation, Vector3.up);
			}
			else if (steer.y < 0)
			{
				_rotation = Quaternion.FromToRotation(baseRotation, Vector3.down);
			}			
		}
	}
}
