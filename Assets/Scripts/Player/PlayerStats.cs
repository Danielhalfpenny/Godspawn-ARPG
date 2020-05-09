using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    #region private properties 

    public Inventory inventory;

    #endregion
    
    #region public properties

    public PlayerType playerType;
    public int health;
    public int maxHealth;
    public static float moveSpeed = 5;
    public Animator animator;
    public GameObject Player;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject Weapon;
    #endregion
    
    public enum PlayerType
    {
        GreatSword,
        Bow,
        Caster
    }
    
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        
        switch (playerType) 
        {
            case PlayerType.Caster:
                animator.runtimeAnimatorController = Resources.Load("AnimationControllers/CasterAnimationController") as RuntimeAnimatorController;
                Player.AddComponent<Caster>();
                break;
            
            case PlayerType.GreatSword:
                animator.runtimeAnimatorController = Resources.Load("AnimationControllers/GreatSwordAnimationController") as RuntimeAnimatorController;
                Weapon = Resources.Load("PlayerWeapons/GreatSword") as GameObject;
                Weapon.tag = "MeleeAttack";
                Weapon.transform.position = new Vector3(0.055f, -0.036f, -0.054f);
                Weapon.transform.rotation = Quaternion.Euler(0, 30, 0);
                Weapon = Instantiate(Weapon, RightHand.transform);
                Player.AddComponent<GreatSword>();
                break;
            
            case PlayerType.Bow:
                animator.runtimeAnimatorController = Resources.Load("AnimationControllers/BowAnimationController") as RuntimeAnimatorController;
                Weapon = Resources.Load("PlayerWeapons/Bow") as GameObject;
                Weapon.transform.position = new Vector3(0.129f, -0.035f, 0.307f);
                Weapon.transform.rotation = Quaternion.Euler(90, -90, 90);
                Weapon = Instantiate(Weapon, LeftHand.transform);
                Player.AddComponent<Bow>();
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
