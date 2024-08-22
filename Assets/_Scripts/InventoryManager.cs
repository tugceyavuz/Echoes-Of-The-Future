using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// TOO everythings will be divided, stats vs from screens
/// </summary>

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject JournalUI;
    public GameObject BGBlur;
    public GameObject[] stats;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI PageTitle;
    public TextMeshProUGUI inventoryFullText; // Text element to show "Inventory full" message
    public bool menuActivated;
    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;

    public bool isItHW1;
    public bool isItHW2;

    private PlaceHW placeHW;

    

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the inventory full message is hidden at the start
        if (inventoryFullText != null)
        {
            inventoryFullText.text = "";
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            BGBlur.SetActive(false);
            Title.text = "";
            InventoryMenu.SetActive(false);
            menuActivated = false;
            for (int i = 0; i < 3; i++)
            {
                stats[i].SetActive(false);
            }
        }else
        {
            placeHW = GameObject.Find("ComputerHW").GetComponent<PlaceHW>();
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
            for (int i = 0; i < 3; i++)
            {
                stats[i].SetActive(false);
            }
        }
        else if (!InventoryMenu.activeInHierarchy)
        {
            if (JournalUI.activeInHierarchy)
            {
                JournalUI.SetActive(false);
                PageTitle.text = "";
            }
            Title.text = "INVENTORY";
            BGBlur.SetActive(true);
            InventoryMenu.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                stats[i].SetActive(true);
            }
            menuActivated = true;
        }
    }

    public bool UseItem(string itemName){
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }
        }
        return false;
    }

    public bool AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        if (itemName == placeHW.HWNames[0])
        {
            isItHW1 = true;
            placeHW.button1.SetActive(true);
            
        }
        if (itemName == placeHW.HWNames[1])
        {
            isItHW2 = true;
            placeHW.button2.SetActive(true);
        }
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

        // Show "Inventory full" message if no slots are available
        if (inventoryFullText != null)
        {
            inventoryFullText.text = "Inventory full";
            StartCoroutine(HideInventoryFullMessage());
        }
        return false;
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
