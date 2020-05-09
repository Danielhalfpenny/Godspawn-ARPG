using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Dictionary<Item.Items, int> items;
    
    private void Awake()
    {
        items = ItemDictionary();
    }

    
    public void AddItem(Item.Items newItem)
    {
        items[newItem] += 1;
        Debug.Log($"picked up {newItem.ToString()}");
        UserInterface.UpdateInventoryUI();
    }

    void RemoveItem(Item.Items newItem)
    {
        items[newItem] -= 1;
    }

    private Dictionary<Item.Items, int> ItemDictionary()
    {
        // Loops through all Item.items enum and creates a dictionary with the key being its name and value is 0
        return Enum.GetValues(typeof(Item.Items)).Cast<Item.Items>().ToDictionary(item => item, item => 0);
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
