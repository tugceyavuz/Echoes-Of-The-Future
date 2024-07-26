using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    public GameObject JournalUI;
    public bool JournalActivated;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenJournal()
    {
        if (JournalActivated)
        {
            JournalUI.SetActive(false);
            JournalActivated = false;
        }
        else if (!JournalActivated)
        {
            JournalUI.SetActive(true);
            JournalActivated = true;
        }
    }
}
