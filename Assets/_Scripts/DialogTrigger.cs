using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [SerializeField] private TextAsset firstInkJSON;  // Ink script for the first interaction
    [SerializeField] private TextAsset subsequentInkJSON;  // Ink script for subsequent interactions

    [SerializeField] private TextAsset traderInkJSON;
    public Trade trading;
    public bool areTheyTrader;

    public string NPCName;
    private TextMeshProUGUI NPCNamePanel;
    public Sprite NPCSprite;

    private Image NPCImage;

    private TextMeshProUGUI dialogText;
    private TextMeshProUGUI popUp;

    private bool playerInRange;
    private bool isFirstInteraction;
    private GameObject canvas;

    private void Awake() {
        canvas = GameObject.Find("Canvas");
        GameObject PopUp = canvas.transform.Find("popUp").gameObject;
        popUp = PopUp.GetComponent<TextMeshProUGUI>();

        GameObject DialogText = canvas.transform.Find("DialogPanel/TextPanel/DialogText").gameObject;
        dialogText = DialogText.GetComponent<TextMeshProUGUI>();

        GameObject NPCimage = canvas.transform.Find("DialogPanel/NPCImagePanel").gameObject;
        NPCImage = NPCimage.GetComponent<Image>();
        
        GameObject NPCName = canvas.transform.Find("DialogPanel/NPCName").gameObject;
        NPCNamePanel = NPCName.GetComponent<TextMeshProUGUI>();
        
        visualCue.SetActive(false);
        playerInRange = false;
        isFirstInteraction = true;  // Initialize the flag for the first interaction
    }

    private void Update() {
        if (playerInRange && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.I))
            {
                NPCNamePanel.text = NPCName;
                NPCImage.sprite = NPCSprite;

                // Check if it's the first interaction
                if (isFirstInteraction)
                {
                    DialogManager.GetInstance().EnterDialogueMode(firstInkJSON);
                    isFirstInteraction = false;  // Set the flag to false after the first interaction
                }
                else
                {
                    if (areTheyTrader && trading.isTradeDone)
                    {
                        DialogManager.GetInstance().EnterDialogueMode(traderInkJSON);
                        return;
                    }else if (areTheyTrader && !trading.isTradeDone){
                        trading.OpenTradePanel();
                        return;
                    }
                    if (subsequentInkJSON != null)
                    {
                        DialogManager.GetInstance().EnterDialogueMode(subsequentInkJSON);
                    }
                   
                }
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            popUp.text = "Press I to interact";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            popUp.text = "";
        }
    }
}
