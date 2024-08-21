using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperPickUp : MonoBehaviour
{
    public TextMeshProUGUI pickupText;
    private bool isPlayerInRange;
    private JournalManager journalManager;

    public string itemName;
    public string itemDescription;

    private void Awake() {
        GameObject PopUp = GameObject.Find("Canvas").transform.Find("popUp").gameObject;
        pickupText = PopUp.GetComponent<TextMeshProUGUI>();
        journalManager = GameObject.Find("Canvas").GetComponent<JournalManager>();
    }
    
    private void Start()
    {
        pickupText.text = "";
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
        bool isAdded = journalManager.AddItemPaper(itemName, itemDescription);
        if (isAdded)
        {
            Destroy(gameObject);
        }else
        {
            return;
        }
    }
}
