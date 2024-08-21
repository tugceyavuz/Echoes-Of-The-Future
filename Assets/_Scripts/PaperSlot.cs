using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics.Tracing;

public class PaperSlot : MonoBehaviour
{
    private string itemName;

    public TextMeshProUGUI ItemName;
    public bool isFull;
    private string itemDescription;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;

    public void AddItem(string itemName, string itemDescription)
    {
        ItemName.text = itemName;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        isFull = true;
    }

    public void Pressed()
    {
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;  
    }

}
