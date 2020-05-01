using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float attackRange;
    

    public float aggroRange;
    
    public CharacterController controller;
    public SphereCollider sphereCollider;
    public Animator animator;

    private bool currentlyChasing;
    private GameObject chasing;
    // Start is called before the first frame update
    private void Start()
    {
        sphereCollider.radius = aggroRange;
        currentlyChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing)
        {
            Chase();
            Debug.Log("CHASING");
            if (inRangeAttack())
            {
                attack();
                Debug.Log("ATTACKING");
            }
            else
            {
                animator.SetBool("Attacking", false);
            }
        }
        // In Attack Range
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
    }
    

    // When a object enters the sphere collider, if player -> start chasing TODO: make work
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
   
        if (!other.gameObject.CompareTag("Player")) return;
        chasing = other.gameObject;
        Chase();
        Debug.Log("CHASING");

    }

    // Uses Attack animation
    // TODO: Damage and visuals
    private void attack()
    {
        animator.SetBool("Attacking", true);
    }

    // Chases player in var player
    private void Chase()
    {
        transform.LookAt(chasing.transform.position);
        animator.SetBool("Moving", true);
        controller.SimpleMove(transform.forward * speed);
    }
    
    // Checks if the enemy is in range of a player to chase
    private bool inRangeAggro()
    {
        return Vector3.Distance(transform.position, chasing.transform.position) < aggroRange;
    }

    // Checks if the enemy is in range of a player to attack
    private bool inRangeAttack()
    {
        return Vector3.Distance(transform.position, chasing.transform.position) < attackRange;
    }
}
