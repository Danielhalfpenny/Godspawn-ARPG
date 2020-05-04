using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class PlayerMovement : MonoBehaviour
{
	#region Public Properties
	public CharacterController controller;
	public Animator animator;
	public bool canAct = true; // locks controls if false.
	#endregion
	
	#region Private Properties
	private float moveSpeed = PlayerStats.moveSpeed;
	private Vector3 _playerMovement;
	#endregion
	
	void Update()
	{
		if (canAct)
		{
			MovePlayer();
		}
	}

	private void MovePlayer()
	{
		//Get input from controls
		var horizontal = Input.GetAxisRaw("Horizontal");
		var vertical = Input.GetAxisRaw("Vertical");
		var speed = moveSpeed;
		if (horizontal != 0 || vertical != 0)
		{
			if (vertical == 0)
				animator.SetInteger("Horizontal", (int) horizontal); 
			else
				animator.SetInteger("Vertical", (int) vertical);
			if (vertical == -1)
			{
				speed *= 0.5f;
			}
		}
		else
		{
			animator.SetInteger("Horizontal", 0);
			animator.SetInteger("Vertical", 0);
		}
		
		var move = transform.right * horizontal + transform.forward * vertical;
		
		controller.Move(move * (speed * Time.deltaTime));
	}

	public void LockControls()
	{
		canAct = false;
	}

	public void UnlockControls()
	{
		canAct = true;
	}

	public bool IsMoving()
	{
		return animator.GetInteger("Horizontal") == 0  && animator.GetInteger("Vertical") == 0;
	}

}