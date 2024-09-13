using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics.Tracing;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public const int maxQuantity = 5;  // Maximum items per slot

    public InventoryManager inventoryManager;

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;
    public Sprite defaultImage;
    public string hexColorCode = "#C9A76B";

    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;
    private AudioSource audioSource;
    private bool IsDrink;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, bool IsDrink)
    {
        if (isFull && this.itemName == itemName)
        {
            IncreaseQuantity(quantity);
        }
        else
        {
            this.IsDrink = IsDrink;
            this.itemName = itemName;
            this.itemSprite = itemSprite;
            this.itemDescription = itemDescription;
            itemImage.sprite = itemSprite;
            itemImage.enabled = true;
            this.quantity = quantity;
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
            isFull = true;
        }

        isClickable = true;
    }

    public void IncreaseQuantity(int quantity)
    {
        int newQuantity = this.quantity + quantity;
        if (newQuantity > maxQuantity)
        {
            this.quantity = maxQuantity;
        }
        else
        {
            this.quantity = newQuantity;
        }
        quantityText.text = this.quantity.ToString();
    }

    public int RemainingCapacity()
    {
        return maxQuantity - this.quantity;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }

    }

    public void UpdateSlotUI()
    {
        // Update the quantity text
        if (quantity > 0)
        {
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
        }
        else
        {
            quantityText.enabled = false;
        }

        // Update the item sprite if it's set
        if (itemSprite != null)
        {
            itemImage.sprite = itemSprite;
            itemImage.enabled = true;
        }
        else
        {
            itemImage.sprite = defaultImage;
            itemImage.enabled = true;
        }

        // Update the item description text and image
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }

    private bool isClickable = false;

    private void OnRightClick()
    {
        bool usable = inventoryManager.UseItem(itemName);
        
        if(usable){  
            if (!IsDrink)
            {
                audioSource.Play();
            }else FindObjectOfType<AudioManager>().Play("drink");
             
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }

    }

    public void EmptySlot()
    {
        Color color = HexToColor(hexColorCode);

        quantityText.enabled = false;
        itemImage.sprite = defaultImage;
        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = defaultImage;
        isFull = false;
        isClickable = false;
    }

    

    void OnLeftClick()
    {
        if (isClickable)
        {
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
        }
    }

    public static Color HexToColor(string hex)
    {
        // Remove the hash at the beginning if it's there
        hex = hex.Replace("#", "");

        // If the hex code is 6 characters, convert it to RGBA
        if (hex.Length == 6)
        {
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color32(r, g, b, 255);
        }
        // If the hex code is 8 characters, include alpha
        else if (hex.Length == 8)
        {
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            byte a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color32(r, g, b, a);
        }
        else
        {
            Debug.LogError("Invalid hex color code.");
            return Color.white; // Default to white if invalid code
        }
    }

    public void DropItemFromSlot(){

        if (isClickable)
        {    
            GameObject itemToDrop = new GameObject(itemName);
            pickUpSrc newItem = itemToDrop.AddComponent<pickUpSrc>();
            newItem.quantity = 1;
            newItem.itemName = itemName;
            newItem.sprite = itemSprite;
            newItem.itemDescription = itemDescription;
            newItem.pickupText = GameObject.Find("popUp").GetComponent<TextMeshProUGUI>();

            SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
            sr.sprite = itemSprite;
            sr.sortingOrder = 4;

            BoxCollider2D collider = itemToDrop.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;

            itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position;

            if(itemName == "Mushroom" || itemName == "Funny Mushroom")
                itemToDrop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
    }


}
