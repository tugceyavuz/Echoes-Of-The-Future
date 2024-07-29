using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalManager : MonoBehaviour
{
    public GameObject JournalUI;
    public GameObject InventoryUI;

    public GameObject BGBlur;
    public bool JournalActivated;
    public TextMeshProUGUI Title;
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
            JournalActivated = true;
        }
    }
}
