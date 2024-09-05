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
        FindObjectOfType<AudioManager>().Play("flip");
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
        FindObjectOfType<AudioManager>().Play("flip");
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
        FindObjectOfType<AudioManager>().Play("flip");
        if (NPC.activeInHierarchy || NewsPapers.activeInHierarchy)
        {
            NewsPapers.SetActive(false);
            NPC.SetActive(false);
        }
        Dictionary.SetActive(true);
        PageTitle.text = "Coding Dictionary";
    }

}

