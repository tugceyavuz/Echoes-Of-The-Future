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
    private Sprite itemImage;
    public GameObject itemDisplayImage;
    //public TMP_Text itemDescriptionNameText;
    //public TMP_Text itemDescriptionText;

    public void AddItem(string itemName, Sprite itemSprite)
    {
        this.itemImage = itemSprite;
        ItemName.text = itemName;
        this.itemName = itemName;
        isFull = true;
    }

    public void Pressed()
    {
        if(itemImage != null) {
            FindObjectOfType<AudioManager>().Play("paper");
            itemDisplayImage.SetActive(true);
            itemDisplayImage.GetComponent<Image>().sprite = itemImage;
        }else itemDisplayImage.SetActive(false);
    }

}
