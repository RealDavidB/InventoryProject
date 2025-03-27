using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InventoryManager : MonoBehaviour
{
    public bool PickedUp = false;

    public int maxStackedItems = 5;
    public S_InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if(Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number < 6)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }
    void ChangeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(S_Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            S_InventorySlot slot = inventorySlots[i];
            S_InventoryDrag itemInSlot = slot.GetComponentInChildren<S_InventoryDrag>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            S_InventorySlot slot = inventorySlots[i];
            S_InventoryDrag itemInSlot = slot.GetComponentInChildren<S_InventoryDrag>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(S_Item item, S_InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        S_InventoryDrag inventoryItem = newItemGo.GetComponent<S_InventoryDrag>();
        inventoryItem.InitialiseItem(item);
    }

    public S_Item GetSelectedItem(bool use)
    {
        S_InventorySlot slot = inventorySlots[selectedSlot];
        S_InventoryDrag itemInSlot = slot.GetComponentInChildren<S_InventoryDrag>();

        if ((int)itemInSlot.item.r_type == 0)
        {
            PickedUp = true;
            //Debug.Log(itemInSlot.item.type);
            if (itemInSlot != null)
            {
                S_Item item = itemInSlot.item;
                if (use == true)
                {
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                    else
                    {
                        itemInSlot.RefreshCount();
                    }
                }
            }
        }
        else
        {
            PickedUp = false;
        }
        
       
        return null;
    }

    public S_Item GetSelectedGrassItem(bool use)
    {
        S_InventorySlot slot = inventorySlots[selectedSlot];
        S_InventoryDrag itemInSlot = slot.GetComponentInChildren<S_InventoryDrag>();

        if ((int)itemInSlot.item.r_type == 1)
        {
            PickedUp = true;
            //Debug.Log(itemInSlot.item.type);
            if (itemInSlot != null)
            {
                S_Item item = itemInSlot.item;
                if (use == true)
                {
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                    else
                    {
                        itemInSlot.RefreshCount();
                    }
                }
            }
        }
        else
        {
            PickedUp = false;
        }


        return null;
    }
}
