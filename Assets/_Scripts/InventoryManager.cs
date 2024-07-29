using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject JournalUI;
     public GameObject BGBlur;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI inventoryFullText; // Text element to show "Inventory full" message
    public bool menuActivated;
    public ItemSlot[] itemSlot;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the inventory full message is hidden at the start
        if (inventoryFullText != null)
        {
            inventoryFullText.text = "";
        }
    }

    // Update is called once per frame
    public void OpenInventory()
    {
        if (InventoryMenu.activeInHierarchy)
        {
            BGBlur.SetActive(false);
            Title.text = "";
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (!InventoryMenu.activeInHierarchy)
        {
            if (JournalUI.activeInHierarchy)
            {
                JournalUI.SetActive(false);
            }
            Title.text = "INVENTORY";
            BGBlur.SetActive(true);
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public bool AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        bool itemAdded = false;
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                itemAdded = true;
                break;
            }
        }

        if (!itemAdded)
        {
            // Show "Inventory full" message if no slots are available
            if (inventoryFullText != null)
            {
                inventoryFullText.text = "Inventory full";
                StartCoroutine(HideInventoryFullMessage());
            }
            return false;
        }

        return true;
    }

    private IEnumerator HideInventoryFullMessage()
    {
        yield return new WaitForSeconds(2f); // Show the message for 2 seconds
        if (inventoryFullText != null)
        {
            inventoryFullText.text = "";
        }
    }
}
