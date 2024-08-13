using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TradeInventory : MonoBehaviour
{
    /// <summary>
    /// ///////////////////////////////////////////////////////////
    /// </summary>
    public ItemSlot[] itemSlot;

    public bool AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Try to stack items in existing slots
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull && itemSlot[i].itemName == itemName && itemSlot[i].quantity < ItemSlot.maxQuantity)
            {
                int remainingCapacity = itemSlot[i].RemainingCapacity();
                if (quantity <= remainingCapacity)
                {
                    itemSlot[i].IncreaseQuantity(quantity);
                    return true;
                }
                else
                {
                    itemSlot[i].IncreaseQuantity(remainingCapacity);
                    quantity -= remainingCapacity;
                }
            }
        }

        // Add items to new slots
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                if (quantity > ItemSlot.maxQuantity)
                {
                    itemSlot[i].AddItem(itemName, ItemSlot.maxQuantity, itemSprite, itemDescription);
                    quantity -= ItemSlot.maxQuantity;
                }
                else
                {
                    itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                    return true;
                }
            }
        }
        return false;
    }
}
