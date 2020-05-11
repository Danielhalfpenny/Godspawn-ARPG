using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public StaticVars staticVars;

    private void Awake()
    {
        staticVars = GetComponent<StaticVars>();
    }

    public void PlayGame(int classInt)
    {
        switch (classInt)
        {
            case 0:
                staticVars.SetPlayerType(PlayerStats.PlayerType.GreatSword); 
                break;
            case 1:
                staticVars.SetPlayerType(PlayerStats.PlayerType.Caster); 
                break;
            case 2:
                staticVars.SetPlayerType(PlayerStats.PlayerType.Bow); 
                break;
        }
        
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
