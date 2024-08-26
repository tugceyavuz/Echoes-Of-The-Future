using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trade : MonoBehaviour
{
    private GameObject TradePanel;
    private GameObject bgBlur;
    private GameObject noMessage;
    private GameObject doneMessage;
    private GameObject tradeApprove;
    public bool isTradeDone;
    private bool isItemReceived;
    public int amount;
    private List<GameObject> slots = new List<GameObject>();
    public string GivenItemName;
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public string itemDescription;
    private InventoryManager inventoryManager;
    private GameObject canvas;

    private void Awake() {
        canvas = GameObject.Find("PanelsCanvas");
        TradePanel = canvas.transform.Find("TradePanel").gameObject;
        tradeApprove = canvas.transform.Find("TradePanel/withResources").gameObject;
        noMessage = canvas.transform.Find("TradePanel/notEnough").gameObject;
        doneMessage = canvas.transform.Find("TradePanel/tradeDone").gameObject;
        bgBlur = canvas.transform.Find("BlurBG").gameObject;
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();

        Transform parentTransform = GameObject.Find("Canvas").transform.Find("InventoryMenu/InventorySlots");

        if (parentTransform != null)
        {
            foreach (Transform slot in parentTransform)
            {
                slots.Add(slot.gameObject);  // Add each child GameObject to the slots list
            }
        }
        else
        {
            Debug.LogError("The specified path does not exist under the Canvas.");
        }
    }

    private void Start() {
        TradePanel.SetActive(false);
        tradeApprove.SetActive(false);
        noMessage.SetActive(false);
        doneMessage.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            TradePanel.SetActive(false);
            bgBlur.SetActive(false);
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
    }

    public void CloseTradePanel(){
        TradePanel.SetActive(false);
        bgBlur.SetActive(false);
    }

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
            tradeApprove.SetActive(false);
            noMessage.SetActive(true);
            return;
        } 
        tradeApprove.SetActive(false);
        doneMessage.SetActive(true);
        isTradeDone = true;
        bgBlur.SetActive(false); 
    }
}
