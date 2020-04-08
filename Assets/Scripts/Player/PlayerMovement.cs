using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public Animator animator;
	public float rotationSpeed = 30;
	public int moveSpeed = 30; // TODO: implement
	
	private Vector3 _inputVec;
	private Vector3 _targetDirection;

	// Scripts per class
	private PlayerClass classScript;
	
	void Update()
	{
		//Get input from controls
		float z = Input.GetAxisRaw("Horizontal");
		float x = -(Input.GetAxisRaw("Vertical"));
		_inputVec = new Vector3(x, 0, z);

		//Apply inputs to animator
		animator.SetFloat("Input X", z);
		animator.SetFloat("Input Z", -(x));
		
		if (x != 0 || z != 0 )  //if there is some input
		{
			//set that character is moving
			animator.SetBool("Moving", true);
		}
		else
		{
			//character is not moving
			animator.SetBool("Moving", false);
		}
		
		//update character position and facing
		UpdateMovement();
	}

	public IEnumerator COStunPause(float pauseTime)
	{
		yield return new WaitForSeconds(pauseTime);
	}

	//converts control input vectors into camera facing vectors
	void GetCameraRelativeMovement()
	{  
		Transform cameraTransform = Camera.main.transform;

		// Forward vector relative to the camera along the x-z plane   
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;

		// Right vector relative to the camera
		// Always orthogonal to the forward vector
		Vector3 right= new Vector3(forward.z, 0, -forward.x);

		//directional inputs
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");

		// Target direction relative to the camera
		_targetDirection = (h * right + v * forward) * moveSpeed;
	}

	//face character along input direction
	void RotateTowardMovementDirection()  
	{
		if(_inputVec != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_targetDirection), Time.deltaTime * rotationSpeed);
		}
	}

	void UpdateMovement()
	{
		//get movement input from controls
		Vector3 motion = _inputVec;

		//reduce input for diagonal movement
		motion *= (Mathf.Abs(_inputVec.x) == 1 && Mathf.Abs(_inputVec.z) == 1) ? 0.7f:1;
		
		RotateTowardMovementDirection();  
		GetCameraRelativeMovement();  
	}

	//Placeholder functions for Animation events
	void Hit()
	{
		
	}

	void Death()
	{
		
	}

	void FootL()
	{
		
	}

	void FootR()
	{
		
	}
	
	
}