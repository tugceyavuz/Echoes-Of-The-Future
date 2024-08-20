using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceObject : MonoBehaviour
{
    public GameObject objectToPlace; // The object to be placed
    public string playerTag = "Player"; // The tag assigned to the player

    private bool isPlayerInRange; // Check if the player is in range
    private Transform playerTransform; // The player's transform

    private TextMeshProUGUI pickupText;
    public int quantity;

    private Vector3 placementOffset = new Vector3(0, 0, 0);

    private GameObject canvas;
    private void Awake() {
        canvas = GameObject.Find("Canvas");
        GameObject PopUp = canvas.transform.Find("popUp").gameObject;
        pickupText = PopUp.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        pickupText.text = "";
        isPlayerInRange = false;
        // Optionally find the player transform by tag if not assigned
        playerTransform = GameObject.FindGameObjectWithTag(playerTag)?.transform;
    }

    void Update()
    {
        // Check for the F key press when the player is in range
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            PlaceTheObject();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger has the player tag
        if (other.CompareTag(playerTag))
        {
            isPlayerInRange = true;
            pickupText.text = "Press F to search";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting the trigger has the player tag
        if (other.CompareTag(playerTag))
        {
            isPlayerInRange = false;
            pickupText.text = "";
        }
    }

    void PlaceTheObject()
    {
        if (playerTransform != null)
        {
            Vector3 placementPosition = playerTransform.position + placementOffset;
            // Instantiate the object at the player's position with the same rotation
            for (int i = 0; i < quantity; i++)
            {
                Instantiate(objectToPlace, placementPosition, playerTransform.rotation);
            }
            pickupText.text = "";
            Destroy(gameObject);
        }
    }
}
