using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceHW : MonoBehaviour
{
    public GameObject InventoryPanel;
    private bool playerInRange;
    public bool isItTrade;
    public bool isHWIcluded;

    public TextMeshProUGUI popup;


    private void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.C))
        {
            InventoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 1;
            InventoryPanel.SetActive(false);
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
}
