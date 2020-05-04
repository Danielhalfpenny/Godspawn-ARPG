using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Attackable : MonoBehaviour
{
    public Animator animator;
    public Image healthBar;
        
    private int health = 100;
    private int maxHealth = 100;
    private bool canAct = true;
    private bool dead = false;
    
    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !dead)
        {
            OnDeath();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger) return;
        var weapon = other.GetComponent<DamageAttack>();
        if (weapon.damage == 0) return;
        Debug.Log($"Did {weapon.damage} damage to object");
        HitAnimation();
        TakeDamage(weapon.damage);
        if (other.CompareTag("ProjectileAttack"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("MeleeAttack"))
        {
            weapon.damage = 0;
        }
    }

    private void HitAnimation()
    {
        StartCoroutine(HitCoroutine());
    }
    
    IEnumerator HitCoroutine()
    {
        canAct = false;
        animator.SetInteger("Hit", 1);
        yield return new WaitForSeconds(0.5f);
        animator.SetInteger("Hit", 0);
        canAct = true;
    }

    private void OnDeath()
    {
        animator.SetInteger("Death", 1);
        Destroy(healthBar.GetComponentInParent<Canvas>());
        Debug.Log("I died");
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = (float) health / maxHealth;
    }
    
    
}
