using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            //inventoryManager.AddItem(itemName, quantity, sprite);
            //Destroy(gameObject);
        }
    }
}
