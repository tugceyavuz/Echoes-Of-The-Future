using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class pickUpSrc : MonoBehaviour
{
    public TextMeshProUGUI pickupText;

    private bool isPlayerInRange;

    private InventoryManager inventoryManager;

    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    [TextArea]
    private string itemDescription;
    
    private void Start()
    {
        pickupText.text = "";
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }

    void Update()
    {
        // Check for the E key press when the player is in range
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger has the player tag
        if (other.CompareTag("Player"))
        {
            // Display the message
            pickupText.text = "Press E to pick it up";
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting the trigger has the player tag
        if (other.CompareTag("Player"))
        {
            // Clear the message
            pickupText.text = "";
            isPlayerInRange = false;
        }
    }


    void PickUpItem() { 
        bool isAdded = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
        if (isAdded)
        {
            Destroy(gameObject);
        }else
        {
            return;
        }
    }
}
