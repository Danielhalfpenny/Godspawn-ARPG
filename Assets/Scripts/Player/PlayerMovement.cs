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
	private bool canAct = true; // locks controls if false.
	private Vector3 _playerMovement;
	private int idleTimer;
	#endregion
	
	
	void Update()
	{
		if (canAct)
		{
			if (Input.GetMouseButtonDown(0))
			{
				//light attack
				StartCoroutine(LightAttackCoroutine());
			}
			else if (Input.GetMouseButtonDown(1))
			{
				//heavy attack
				StartCoroutine(HeavyAttackCoroutine());
			}
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
			if (vertical == 0)
				animator.SetInteger("Strafe", (int) horizontal); 
			else
				animator.SetInteger("Direction", (int) vertical);
			animator.SetTrigger("ExitIdle");
			animator.SetInteger("Speed", 1);
		}
		else
		{
			animator.SetInteger("Strafe", 0);
			animator.SetInteger("Direction", 0);

			animator.ResetTrigger("ExitIdle");
			animator.SetInteger("Speed", 0);
			idleTimer++;
			if (idleTimer > 5000)
			{
				RandomIdleAnimation();
			}
		}
		
		var move = transform.right * horizontal + transform.forward * vertical;
		
		controller.Move(move * (moveSpeed * Time.deltaTime));
	}

	public void LockControls()
	{
		canAct = false;
	}

	public void UnlockControls()
	{
		canAct = true;
	}

	private void RandomIdleAnimation()
	{
		animator.SetInteger("Idle", new Random().Next(1,5));
		Debug.Log("Random Idle Animation");
		animator.SetInteger("Idle", 0);

		idleTimer = 0;
	}

	IEnumerator LightAttackCoroutine()
	{
		canAct = false;
		animator.SetInteger("Attack", 1);
		yield return new WaitForSeconds(1f);
		animator.SetInteger("Attack", 0);
		canAct = true;
	}
	
	IEnumerator HeavyAttackCoroutine()
	{
		canAct = false;
		animator.SetInteger("Attack", 2);
		yield return new WaitForSeconds(1.5f);
		animator.SetInteger("Attack", 0);
		canAct = true;
	}

}