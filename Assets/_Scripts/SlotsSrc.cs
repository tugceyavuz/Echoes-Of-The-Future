using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics.Tracing;

public class SlotsSrc : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// /////////////////////////////////////////////
    /// </summary>
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public const int maxQuantity = 5;  // Maximum items per slot

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;
    public Sprite defaultImage;
    public string hexColorCode = "#C9A76B";

    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        if (isFull && this.itemName == itemName)
        {
            IncreaseQuantity(quantity);
        }
        else
        {
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

    }

    private bool isClickable = false;

    private void EmptySlot()
    {
        Color color = HexToColor(hexColorCode);

        quantityText.enabled = false;
        itemImage.sprite = defaultImage;
        itemImage.color = color;
        itemDescriptionNameText.text = "";
        itemDescriptionImage.sprite = defaultImage;
        isFull = false;
        isClickable = false;
    }

    void OnLeftClick()
    {
        if(isClickable){    
            itemDescriptionNameText.text = itemName;
            itemDescriptionImage.sprite = itemSprite;
            
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            } 
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

}
