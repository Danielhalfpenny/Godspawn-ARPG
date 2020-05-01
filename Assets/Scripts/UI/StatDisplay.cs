using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text StatText;
    public GameObject player;
    private PlayerStats playerStats;
 
    //^only temporary, max health should probably be a stat within the class which can be called into this script.

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {

        StatText.text = "Health: " + playerStats.health + "/" + playerStats.maxHealth;

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            playerStats.health--;
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus) && playerStats.health < playerStats.maxHealth)
        {
            playerStats.health++;
        }

        if (Input.GetKeyDown("space"))
        {
            print("this is for testing purposes");
        }

 
    }


}