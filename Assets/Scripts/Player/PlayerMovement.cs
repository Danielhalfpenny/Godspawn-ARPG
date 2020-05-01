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
	public float moveSpeed = 30;
	public int damage = 0;
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
		var speed = moveSpeed;
		if (horizontal != 0 || vertical != 0)
		{
			if (vertical == 0)
				animator.SetInteger("Strafe", (int) horizontal); 
			else
				animator.SetInteger("Direction", (int) vertical);
			if (vertical == -1)
			{
				speed *= 0.5f;
			}
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
		damage = 10;
		animator.SetInteger("Attack", 1);
		yield return new WaitForSeconds(1f);
		animator.SetInteger("Attack", 0);
		damage = 0;
		canAct = true;
	}
	
	IEnumerator HeavyAttackCoroutine()
	{
		canAct = false;
		damage = 25;
		animator.SetInteger("Attack", 2);
		var move = transform.right * 0 + transform.forward * 2;
		controller.Move(move * (moveSpeed * Time.deltaTime));
		yield return new WaitForSeconds(1.5f);
		animator.SetInteger("Attack", 0);
		damage = 0;
		canAct = true;
	}

}