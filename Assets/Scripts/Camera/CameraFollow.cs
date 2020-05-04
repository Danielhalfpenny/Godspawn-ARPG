using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
	#region public properties
	public GameObject playerObj;
	public float cameraMoveSpeed = 120.0f;
	public GameObject cameraFollowObj;
	public float clampAngle = 80.0f;
	public float inputSensitivity = 150.0f;
	public float distanceFromPlayer = 5;
	
	#endregion
	#region private properties
	private float rotY = 0.0f;
	private float rotX = 0.0f;
	private float mouseX;
	private float mouseY;
	private float finalInputX;
	private float finalInputZ;
	private Camera cameraObj;
	private PlayerMovement playerMovement;
	#endregion
	
	private void Start()
	{
		cameraObj = GetComponentInChildren<Camera>();
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked; // Locks in middle of screen
		Cursor.visible = false; // Hides cursor
		cameraObj.transform.position = new Vector3(0.0f, 2.0f, distanceFromPlayer);
		playerMovement = playerObj.GetComponent<PlayerMovement>();
	}

	private void Update()
	{
		float inputX = Input.GetAxis("RightStickHorizontal");
		float inputZ = Input.GetAxis("RightStickVertical");
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");
		finalInputX = inputX + mouseX;
		finalInputZ = inputZ + mouseY;

		rotY += finalInputX * inputSensitivity * Time.deltaTime;
		rotX -= finalInputZ * inputSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
		
		var localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;

		if (!playerMovement.IsMoving())
		{
			var playerRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
			playerObj.transform.rotation = playerRotation;
		}
		
	}

	private void LateUpdate()
	{
		CameraUpdater();
	}

	void CameraUpdater()
	{
		Transform target = cameraFollowObj.transform;

		float step = cameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}


}