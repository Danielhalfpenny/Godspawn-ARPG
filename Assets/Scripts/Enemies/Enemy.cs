using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float attackRange;
    public CharacterController controller;
    public Animator animator;
    
    public Transform player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        chasePlayer(); // Todo: add agro range
        
        if (inRange())
        {
            attack();
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
        
    }

    // Checks if the enemy is in range of a player
    bool inRange()
    {
        return Vector3.Distance(transform.position, player.position) < attackRange;
    }
    
    // Uses Attack animation
    // TODO: add dodgeable line and damage
    void attack()
    {
        animator.SetBool("Attacking", true);
    }

    // Chases player in var player
    void chasePlayer()
    {
        transform.LookAt(player.position);
        animator.SetBool("Moving", true);
        controller.SimpleMove(transform.forward * speed);
    }
}
