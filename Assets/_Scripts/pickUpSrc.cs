using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class pickUpSrc : MonoBehaviour
{
    private AudioSource audioSource;
    public TextMeshProUGUI pickupText;
    private bool isPlayerInRange;
    private InventoryManager inventoryManager;

    private SpriteRenderer sr;

    public string itemName;
    public bool IsDrink;
    public int quantity;
    public Sprite sprite;
    public string itemDescription;

    private void Awake() {
        GameObject PopUp = GameObject.Find("Canvas").transform.Find("popUp").gameObject;
        pickupText = PopUp.GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }
    
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
        bool isAdded = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription, IsDrink);
        if (isAdded)
        {
            FindObjectOfType<AudioManager>().Play("pickUp");
            Destroy(gameObject);
        }else
        {
            return;
        }
    }
}
