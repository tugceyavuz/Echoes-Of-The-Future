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
    private Trade trading;
    public bool areTheyTrader;

    public string NPCName;
    private TextMeshProUGUI NPCNamePanel;
    public Sprite NPCSprite;
    public string NPCInfo;
    private Image NPCImage;

    private TextMeshProUGUI dialogText;
    private TextMeshProUGUI popUp;

    private JournalManager journalManager;
    private InventoryManager inventoryManager;
    private bool playerInRange;
    public bool isFirstInteraction;
    private GameObject canvas;
    private GameObject Pcanvas;
    private DialogManager dialogManager;
    private List<GameObject> slots = new List<GameObject>();

    public bool IsWoman;

    private void Awake() {
        canvas = GameObject.Find("Canvas");
        journalManager = canvas.GetComponent<JournalManager>();
        inventoryManager = canvas.GetComponent<InventoryManager>();

        Pcanvas = GameObject.Find("PanelsCanvas");
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();

        GameObject PopUp = Pcanvas.transform.Find("popUp").gameObject;
        popUp = PopUp.GetComponent<TextMeshProUGUI>();

        GameObject DialogText = Pcanvas.transform.Find("DialogPanel/TextPanel/DialogText").gameObject;
        dialogText = DialogText.GetComponent<TextMeshProUGUI>();

        GameObject NPCimage = Pcanvas.transform.Find("DialogPanel/NPCImagePanel").gameObject;
        NPCImage = NPCimage.GetComponent<Image>();
        
        GameObject NPCName = Pcanvas.transform.Find("DialogPanel/NPCName").gameObject;
        NPCNamePanel = NPCName.GetComponent<TextMeshProUGUI>();

        trading = GameObject.Find("Managers/TradeManager").GetComponent<Trade>();
        
        visualCue.SetActive(false);
        playerInRange = false;
        isFirstInteraction = true;  // Initialize the flag for the first interaction

        Transform parentTransform = GameObject.Find("Canvas").transform.Find("JournalPanel/NPCPanel/NPCList");

        if (parentTransform != null)
        {
            foreach (Transform slot in parentTransform)
            {
                slots.Add(slot.gameObject);  // Add each child GameObject to the slots list
            }
        }
        else
        {
            Debug.LogError("The specified path does not exist under the Canvas.");
        }
    }

    private void Update() {
        if (playerInRange && !dialogManager.dialogueIsPlaying)
        {
            if (journalManager.JournalActivated || inventoryManager.menuActivated)
            {
                popUp.text = "";
            }else popUp.text = "Press F to interact";

            if (isFirstInteraction) 
                visualCue.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.F) && !journalManager.JournalActivated && !inventoryManager.menuActivated)
            {
                NPCNamePanel.text = NPCName;
                NPCImage.sprite = NPCSprite;

                // Check if it's the first interaction
                if (isFirstInteraction)
                {
                    AddToJournal();
                    dialogManager.EnterDialogueMode(firstInkJSON, IsWoman);
                    isFirstInteraction = false;  // Set the flag to false after the first interaction
                }
                else
                {
                    if (areTheyTrader && trading.isTradeDone)
                    {
                       dialogManager.EnterDialogueMode(traderInkJSON, IsWoman);
                        return;
                    }else if (areTheyTrader && !trading.isTradeDone){
                        trading.OpenTradePanel();
                        return;
                    }
                    else if (!areTheyTrader && subsequentInkJSON != null)
                    {
                        dialogManager.EnterDialogueMode(subsequentInkJSON, IsWoman);
                    }
                   
                }
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }


    private void AddToJournal(){
        bool flag = false;
        foreach (GameObject slot in slots)
        {
            if(NPCName == slot.GetComponent<NPCSlots>().ItemName.text)
                flag = true;
        }
        if(!flag)
            journalManager.AddItemNPC(NPCName, NPCSprite, NPCInfo);
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
