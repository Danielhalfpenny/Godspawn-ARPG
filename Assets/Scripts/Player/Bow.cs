using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private PlayerStats playerStats;
    private Animator animator;
    private Animator bowAnimator;

    private GameObject arrowObj;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
        bowAnimator = playerStats.Weapon.GetComponent<Animator>();
        arrowObj = Resources.Load("PlayerWeapons/Arrow") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.canAct)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //light attack
                StartCoroutine(LightAttackCoroutine());
            }
            else if (Input.GetMouseButtonDown(1))
            {
                //heavy attack
                // StartCoroutine(HeavyAttackCoroutine());
            }
        }
    }
    
    IEnumerator LightAttackCoroutine()
    {
        playerMovement.canAct = false;
        animator.SetInteger("Attack", 1);
        yield return new WaitForSeconds(0.3f);
        bowAnimator.SetBool("PullBack", true);
        yield return new WaitForSeconds(0.5f);
        var firedArrow = Instantiate(arrowObj, playerStats.RightHand.transform);
        firedArrow.tag = "ProjectileAttack";
        firedArrow.GetComponent<Arrow>().Fire();
        bowAnimator.SetBool("PullBack", false);
        animator.SetInteger("Attack", 0);
        playerMovement.canAct = true;
    }
	
    IEnumerator HeavyAttackCoroutine()
    {
        playerMovement.canAct = false;
        animator.SetInteger("Attack", 2);
        var move = transform.right * 0 + transform.forward * 2;
        yield return new WaitForSeconds(1.5f);
        animator.SetInteger("Attack", 0);
        playerMovement.canAct = true;
    }
}
