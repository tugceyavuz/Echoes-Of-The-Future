using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trade : MonoBehaviour
{
    public GameObject TradePanel;
    public GameObject bgBlur;
    public GameObject noMessage;
    public GameObject doneMessage;
    public GameObject tradeApprove;
    public bool isTradeDone;
    private bool isItemReceived;
    public int amount;
    public List<GameObject> slots;
    public string GivenItemName;
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public string itemDescription;

    private void Start() {
        TradePanel.SetActive(false);
        tradeApprove.SetActive(false);
        noMessage.SetActive(false);
        doneMessage.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 1;
            TradePanel.SetActive(false);
        }

        if (isTradeDone && !isItemReceived)
        {
            ReceiveItem();
            isItemReceived = true;
        }
    }

    public void OpenTradePanel(){
        TradePanel.SetActive(true);
        bgBlur.SetActive(true);
        tradeApprove.SetActive(true);
        noMessage.SetActive(false);
        doneMessage.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseTradePanel(){
        Time.timeScale = 1;
        TradePanel.SetActive(false);
        bgBlur.SetActive(false);
        Time.timeScale = 1;
    }

    public InventoryManager inventoryManager;

    public void ReceiveItem(){
        inventoryManager.AddItem(itemName, quantity, itemSprite, itemDescription);
    }


    public void TradeItem()
    {
        // Get the Text component of the child object of the button to retrieve the item name
        if (GivenItemName == null)
        {
            Debug.LogError("no string entered");
            return;
        }

        // Iterate over each slot in the inventory
        for (int i = 0; i < slots.Count; i++)
        {
            GameObject slot = slots[i];

            ItemSlot item = slot.GetComponent<ItemSlot>();

            if (amount <= 0)
            {
                break;
            }

            if (item != null && item.itemName == GivenItemName)
            {
                if (amount >= item.quantity)
                {
                    amount -= item.quantity;
                    item.EmptySlot();
                }
                else{
                    item.quantity -= amount;
                }
            }
        }

        if (amount > 0)
        {
            Time.timeScale = 1; 
            tradeApprove.SetActive(false);
            noMessage.SetActive(true);
            return;
        }

        Time.timeScale = 1;  
        tradeApprove.SetActive(false);
        doneMessage.SetActive(true);
        isTradeDone = true;
        bgBlur.SetActive(false); 
    }
}
