using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public Items item;

    void Awake()
    {
        item = Items.TestItem;
    }

    public enum Items
    {
        TestItem
    }

    public Items ItemName()
    {
        return item;
    }

    public void PickUp(GameObject player)
    {
        player.GetComponent<Inventory>().AddItem(item);
        Destroy(gameObject);
    }
}
