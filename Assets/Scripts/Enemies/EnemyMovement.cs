using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    
    private CharacterController controller;
    private Animator animator;
    private bool currentlyChasing;
    private GameObject chasing;
    private Attackable attackableScript;
    
    // Start is called before the first frame update
    // TODO: Hit Coroutine to stop movement when hit and play animation
    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        attackableScript = gameObject.GetComponent<Attackable>();
        chasing = player.gameObject;
        currentlyChasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyChasing && !attackableScript.IsDead())
        {
            animator.SetInteger("Vertical", 1);
            Chase();
        }
        else
        {
            animator.SetInteger("Vertical", 0);
        }
    }
    

    // Chases player in var player
    private void Chase()
    {
        var playerPos = chasing.transform;
        transform.LookAt(playerPos);
        controller.SimpleMove(transform.forward * speed);
    }
    

}
