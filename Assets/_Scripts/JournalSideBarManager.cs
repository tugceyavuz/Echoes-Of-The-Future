using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalSideBarManager : MonoBehaviour
{
    public GameObject NPC;
    public GameObject NewsPapers;
    public GameObject Dictionary;
    public TextMeshProUGUI PageTitle;

    public void OpenNPC()
    {
        if (NewsPapers.activeInHierarchy || Dictionary.activeInHierarchy)
        {
            NewsPapers.SetActive(false);
            Dictionary.SetActive(false);
        }
        NPC.SetActive(true);
        PageTitle.text = "Characters Page";
    }

    public void OpenNews()
    {
        if (NPC.activeInHierarchy || Dictionary.activeInHierarchy)
        {
            NPC.SetActive(false);
            Dictionary.SetActive(false);
        }
        NewsPapers.SetActive(true);
        PageTitle.text = "Collected Documents Page";
    }

    public void OpenDictionary()
    {
        if (NPC.activeInHierarchy || NewsPapers.activeInHierarchy)
        {
            NewsPapers.SetActive(false);
            NPC.SetActive(false);
        }
        Dictionary.SetActive(true);
        PageTitle.text = "Coding Dictionary";
    }

}

