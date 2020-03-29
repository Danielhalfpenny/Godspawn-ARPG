using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public enum PlayerClassEnum{ Mage, Warrior, Ranger };
    public PlayerClassEnum playerClass;

    private GameObject _playerModel;
    
    public void Start()
    {
        // Sets player model to chosen class
        switch (playerClass)
        {
            case PlayerClassEnum.Mage:
                _playerModel = Resources.Load("MageModel", typeof(GameObject)) as GameObject;
                break;
            
            case PlayerClassEnum.Ranger:
                _playerModel = Resources.Load("RangerModel", typeof(GameObject)) as GameObject;
                break;
            
            case PlayerClassEnum.Warrior:
                _playerModel = Resources.Load("WarriorModel", typeof(GameObject)) as GameObject;
                break;
        }
        // Creates Player Model on player spawn
        Instantiate(_playerModel, transform); 
        
        // TODO: Attach Smooth Follow Camera
    }

}
