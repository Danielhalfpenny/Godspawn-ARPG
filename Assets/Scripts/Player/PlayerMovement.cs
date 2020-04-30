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
	public int moveSpeed = 30;
	#endregion
	
	#region Private Properties
	private bool canMove = true; // locks controls if false.
	private Vector3 _playerMovement;
	private int idleTimer;
	#endregion
	
	
	void Update()
	{
		if (canMove)
		{
			MovePlayer();
		}
	}

	private void MovePlayer()
	{
		//Get input from controls
		var horizontal = Input.GetAxisRaw("Horizontal");
		var vertical = Input.GetAxisRaw("Vertical");

		if (horizontal != 0 || vertical != 0)
		{
			animator.SetTrigger("ExitIdle");
			animator.SetInteger("Speed", 1);
		}
		else
		{
			animator.ResetTrigger("ExitIdle");
			idleTimer++;
			if (idleTimer > 500)
			{
				RandomIdleAnimation();
			}
			animator.SetInteger("Speed", 0);
		}
		
		var move = transform.right * horizontal + transform.forward * vertical;
		
		controller.Move(move * (moveSpeed * Time.deltaTime));
	}

	public void LockControls()
	{
		canMove = false;
	}

	public void UnlockControls()
	{
		canMove = true;
	}

	private void RandomIdleAnimation()
	{
		animator.SetInteger("Idle", new Random().Next(1,5));
		idleTimer = 0;
	}


}