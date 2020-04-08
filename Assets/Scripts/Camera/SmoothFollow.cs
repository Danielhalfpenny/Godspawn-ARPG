using System;
using UnityEngine;


public class SmoothFollow : MonoBehaviour
{
	#region Consts
	private const float SMOOTH_TIME = 0.3f;
	#endregion
	
	#region Public Properties
	public float offSetX, offSetY, offSetZ;
	public bool LockX, LockY, LockZ;
	public bool useSmoothing;
	private GameObject target;

	public GameObject hudElements;
	#endregion
	
	#region Private Properties
	private Transform thisTransform;
	private Vector3 velocity;
	bool hudActive = true;
	private void Awake()
	{
		thisTransform = transform;
		velocity = new Vector3(0.5f, 0.5f, 0.5f);
	}

	void Update()
	{
		target = GameObject.FindWithTag("Player");

		if(hudActive)
		{
			if (Input.GetKeyDown(KeyCode.H))
			{
				hudElements.SetActive (false);
				hudActive = false;
			}

		}
		else
		{
			if (Input.GetKeyDown(KeyCode.H))
			{
				hudElements.SetActive (true);
				hudActive = true;
			}
		}
	}

	// ReSharper disable UnusedMember.Local
	private void LateUpdate()
		// ReSharper restore UnusedMember.Local
	{
		var newPos = Vector3.zero;
		
		if (useSmoothing)
		{

			newPos.x = Mathf.SmoothDamp(thisTransform.position.x, target.transform.position.x + offSetX, ref velocity.x, SMOOTH_TIME);
			newPos.y = Mathf.SmoothDamp(thisTransform.position.y, target.transform.position.y + offSetY, ref velocity.y, SMOOTH_TIME);
			newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.transform.position.z + offSetZ, ref velocity.z, SMOOTH_TIME);
		}
		else
		{
			newPos.x = target.transform.position.x;
			newPos.y = target.transform.position.y;
			newPos.z = target.transform.position.z;
		}
		
		#region Locks
		if (LockX)
		{
			newPos.x = thisTransform.position.x;
		}
		
		if (LockY)
		{
			newPos.y = thisTransform.position.y;
		}
		
		if (LockZ)
		{
			newPos.z = thisTransform.position.z;
		}
		#endregion
		
		transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
	}
}