using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region public properties

    public PlayerType playerType;
    public int health;
    public int maxHealth;
    public static float moveSpeed = 5;
    public Animator animator;
    public GameObject Player;
    public GameObject LeftHand;
    public GameObject RightHand;
    #endregion
    
    public enum PlayerType
    {
        GreatSword,
        Bow,
        NoWeapon
    }



    private void Start()
    {
        //TODO: make playerType add weapon to hand (Attach to appropriate limb to allow for it to move correctly)
        // BowClass
        // Wooden bow -> attach LeftHand -> transform (0.129, -0.035, 0.307) -> rotation(90, -90, 90)
        // Arrow -> attach RightHand -> transform (0.206, -0.025, 0.019) -> rotation(90, -90, -180)
        
        // GreatSwordClass
        // Great Sword -> attach RightHand -> transform(0.055, -0.036, -0.054) -> rotation (0, 30, 0)
        switch (playerType) 
        {
            case PlayerType.NoWeapon:
                break;
            
            case PlayerType.GreatSword:
                animator.runtimeAnimatorController = Resources.Load("AnimationControllers/GreatSwordAnimationController") as RuntimeAnimatorController;
                var greatSwordObj = Resources.Load("PlayerWeapons/GreatSword") as GameObject;
                greatSwordObj.transform.position = new Vector3(0.055f, -0.036f, -0.054f);
                greatSwordObj.transform.rotation = Quaternion.Euler(0, 30, 0);
                Instantiate(greatSwordObj, RightHand.transform);
                Player.AddComponent<GreatSword>();
                break;
            
            case PlayerType.Bow:
                animator.runtimeAnimatorController = Resources.Load("AnimationControllers/BowAnimationController") as RuntimeAnimatorController;
                var bowObj = Resources.Load("PlayerWeapons/Bow") as GameObject;
                var ArrowObj = Resources.Load("PlayerWeapons/Arrow") as GameObject;
                bowObj.transform.position = new Vector3(0.129f, -0.035f, 0.307f);
                ArrowObj.transform.position = new Vector3(0.206f, -0.025f, 0.019f);
                bowObj.transform.rotation = Quaternion.Euler(90, -90, 90);
                ArrowObj.transform.rotation = Quaternion.Euler(90, -90, -180);
                Instantiate(bowObj, LeftHand.transform);
                Instantiate(ArrowObj, RightHand.transform);
                Player.AddComponent<Bow>();
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
