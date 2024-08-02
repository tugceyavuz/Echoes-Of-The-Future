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
    public GameObject NewsPapers;
    public bool JournalActivated;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI PageTitle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenJournal()
    {
        if (JournalUI.activeInHierarchy)
        {
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
            if (InventoryUI.activeInHierarchy)
            {
                InventoryUI.SetActive(false);
            }
            BGBlur.SetActive(true);
            Title.text = "JOURNAL";
            JournalUI.SetActive(true);
            NewsPapers.SetActive(false);
            NPC.SetActive(false);
            JournalActivated = true;
            for (int i = 0; i < 3; i++)
            {
                stats[i].SetActive(true);
            }
        }
    }
}
