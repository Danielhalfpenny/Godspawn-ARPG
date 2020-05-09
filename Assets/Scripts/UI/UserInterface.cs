using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    private static Text statText;
    private static Text inventoryText;
    public GameObject player;
    
    
    private static PlayerStats playerStats;
    
    
    //^only temporary, max health should probably be a stat within the class which can be called into this script.

    private void Awake()
    {
        foreach (var component in gameObject.GetComponentsInChildren<Text>())
        {
            switch (component.name)
            {
                case "Stats":
                    statText = component;
                    break;
                case "Inventory":
                    inventoryText = component;
                    break;
            }
        }
        playerStats = player.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        statText.text = "Health: " + playerStats.health + "/" + playerStats.maxHealth;
    }

    public static void UpdateInventoryUI()
    {
        Debug.Log("Updating Inv");
        var inv = playerStats.inventory.items;
        inventoryText.text  = inv.Where(item => item.Value > 0).Aggregate("Inventory:\n", (current, item) => current + $"{item.Key}, {item.Value}\n");
    }
    


}