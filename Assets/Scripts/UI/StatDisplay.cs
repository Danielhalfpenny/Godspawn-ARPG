using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text StatText;
    private int Health;
    private int MaxHealth =100;
    private int Mana;
    private int MaxMana = 100;
    //^only temporary, max health should probably be a stat within the class which can be called into this script.

    void Start()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        //currently pointless, essentially futureproofing for when MaxHealth is being pulled from another script
        InvokeRepeating("ManaRegen", 0f, 1f);
    }

    void Update()
    {

        StatText.text = "Health: " + Health + "/" + MaxHealth +"\nMana: " + Mana + "/" + MaxMana;

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Health--;
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus) && Health < MaxHealth)
        {
            Health++;
        }

        if (Input.GetKeyDown("space"))
        {
            print("this is for testing purposes");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)&& Mana > 29)
        {
            Mana = Mana - 30;
            //30 is just a random amount, it'll probably be replaced by a cost variable
        }
    }

    void ManaRegen()
    {
        if (Mana < MaxMana)
        {
            Mana++;
        }
    }
}