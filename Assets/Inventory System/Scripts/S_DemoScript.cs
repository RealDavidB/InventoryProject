using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DemoScript : MonoBehaviour
{
    public S_InventoryManager inventoryManager;
    public S_Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
    }

    public void GetSelectedItem()
    {
        S_Item receivedItem = inventoryManager.GetSelectedItem(false);
    }

    public void UseSelectedItem()
    {
        S_Item receivedItem = inventoryManager.GetSelectedItem(true);
    }

    public void UseSelectedGrassItem()
    {
        S_Item receivedItem = inventoryManager.GetSelectedGrassItem(true);
    }
}
