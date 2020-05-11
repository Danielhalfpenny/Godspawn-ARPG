using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVars : MonoBehaviour
{
    // To pass vars across scenes
    
    public static PlayerStats.PlayerType playerType;

    public void SetPlayerType(PlayerStats.PlayerType newPlayerType)
    {
        playerType = newPlayerType;
    }
    
}
