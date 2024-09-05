using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalManager : MonoBehaviour
{
    public GameObject JournalUI;
    public GameObject InventoryUI;
    public GameObject[] stats;
    public GameObject BGBlur;
    public GameObject NPC;
    public GameObject Dictionary;
    public GameObject NewsPapers;
    public bool JournalActivated;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI PageTitle;

    public PaperSlot[] itemSlot;
    public NPCSlots[] NPCSlot;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (JournalUI.activeInHierarchy)
            {
                FindObjectOfType<AudioManager>().Play("closeBook");
            }
            Time.timeScale = 1;
            JournalUI.SetActive(false);
            BGBlur.SetActive(false);
            JournalActivated = false;
            Title.text = "";
            for (int i = 0; i < 3; i++)
            {
                stats[i].SetActive(false);
            }
            PageTitle.text = "";
        }
    }

    public void OpenJournal()
    {
        if (JournalUI.activeInHierarchy)
        {
            FindObjectOfType<AudioManager>().Play("closeBook");
            Time.timeScale = 1;
            JournalUI.SetActive(false);
            BGBlur.SetActive(false);
            JournalActivated = false;
            Title.text = "";
            for (int i = 0; i < 3; i++)
            {
                stats[i].SetActive(false);
            }
            PageTitle.text = "";
        }
        else if (!JournalUI.activeInHierarchy)
        {
            FindObjectOfType<AudioManager>().Play("openBook");
            if (InventoryUI.activeInHierarchy)
            {
                InventoryUI.SetActive(false);
            }
            BGBlur.SetActive(true);
            Title.text = "JOURNAL";
            Dictionary.SetActive(false);
            JournalUI.SetActive(true);
            NewsPapers.SetActive(true);
            PageTitle.text = "Collected Documents Page";
            NPC.SetActive(false);
            JournalActivated = true;
            for (int i = 0; i < 3; i++)
            {
                stats[i].SetActive(true);
            }
            Time.timeScale = 0;
        }
    }

    public bool AddItemNPC(string itemName,  Sprite itemSprite, string itemDescription)
    {
        // Add items to new slots
        for (int i = 0; i < NPCSlot.Length; i++)
        {
            if (!NPCSlot[i].isFull)
            {

                NPCSlot[i].AddItem(itemName, itemSprite, itemDescription);
                return true;  
            }
        }
        return false;
    }


    public bool AddItemPaper(string itemName, Sprite itemSprite)
    {
        // Add items to new slots
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {

                itemSlot[i].AddItem(itemName, itemSprite);
                return true;  
            }
        }
        return false;
    }


}
