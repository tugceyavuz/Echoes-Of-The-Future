using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlaceHW : MonoBehaviour
{
    public GameObject PopUpPanel;
    public GameObject BGBlur;
    public GameObject withHW;
    public GameObject noHW;
    private bool playerInRange;
    public bool isItTrade;
    public bool isHWIcluded;

    public TextMeshProUGUI popup;
    private InventoryManager inventoryManager ;

    private void Start() {
        inventoryManager =  GameObject.Find("Canvas").GetComponent<InventoryManager>();
        noHW.SetActive(true);
        withHW.SetActive(false);
        HWPlaced.SetActive(false);
    }


    private void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.C))
        {
            BGBlur.SetActive(true);
            PopUpPanel.SetActive(true);
            if (inventoryManager.isItHW1 || inventoryManager.isItHW2 && !isHWIcluded)
            {
                noHW.SetActive(false);
                withHW.SetActive(true);
            }
            else if(!isHWIcluded){
                noHW.SetActive(true);
            }
            else{
                noHW.SetActive(false);
                HWPlaced.SetActive(true);
            }
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 1;
            withHW.SetActive(false);
            PopUpPanel.SetActive(false);
            BGBlur.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            popup.text = "Press C to interact";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            popup.text = "";
        }
    }

    public List<GameObject> slots;
    public GameObject HWPlaced;
    public string usedItem;

    public void UseItem(TextMeshProUGUI buttonName)
    {
        // Get the Text component of the child object of the button to retrieve the item name
        if (buttonName == null)
        {
            Debug.LogError("Button has no child Text component");
            return;
        }

        string itemName = buttonName.text;
        usedItem = buttonName.text;

        // Iterate over each slot in the inventory
        for (int i = 0; i < slots.Count; i++)
        {
            GameObject slot = slots[i];

            ItemSlot item = slot.GetComponent<ItemSlot>();

            if (item != null && item.itemName == itemName)
            {
                Time.timeScale = 1;
                item.EmptySlot();
    
                withHW.SetActive(false);
                HWPlaced.SetActive(true);
                inventoryManager.isItHW1 = false;
                inventoryManager.isItHW2 = false;
                isHWIcluded = true;

                PopUpPanel.SetActive(false);
                BGBlur.SetActive(false); 
                return;
            }
        }
 
    }
}
