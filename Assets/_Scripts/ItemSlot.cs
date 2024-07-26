using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;



    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;


    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;


    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription){

        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;   
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        isFull = true;  
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
           OnLeftClick();
        }
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
        }
    }

    void OnLeftClick(){
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }
}
