using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics.Tracing;

public class NPCSlots : MonoBehaviour
{
    private string itemName;
    public Sprite itemSprite;
    public TextMeshProUGUI ItemName;
    public bool isFull;
    private string itemDescription;
    public TMP_Text itemDescriptionNameText;
    public Image itemDescriptionImage;
    public Image itemImage;
    public TMP_Text itemDescriptionText;

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription)
    {
        ItemName.text = itemName;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        isFull = true;
    }

    public void Pressed()
    {
        itemDescriptionImage.sprite = itemSprite;
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription; 
    }

}
