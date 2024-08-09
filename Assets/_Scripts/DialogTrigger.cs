using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [SerializeField] private TextAsset inkJSON;

    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI popUp;
    private bool playerInRange;
    private void Awake() {
        visualCue.SetActive(false);
        playerInRange = false;
    }

    private void Update() {
        if (playerInRange && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.I))
            {
                DialogManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }else
        {
            visualCue.SetActive(false);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") == true)
        {
            playerInRange = true;
            popUp.text = "Press I to interact";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") == true)
        {
            playerInRange = false;
            popUp.text = "";
        }
        
    }
}
