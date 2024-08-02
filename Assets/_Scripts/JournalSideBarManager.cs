using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalSideBarManager : MonoBehaviour
{
    public GameObject NPC;
    public GameObject NewsPapers;
    public TextMeshProUGUI PageTitle;

    public void OpenNPC()
    {
        if (NewsPapers.activeInHierarchy)
        {
            NewsPapers.SetActive(false);
        }
        NPC.SetActive(true);
        PageTitle.text = "Characters Page";
    }

    public void OpenNews()
    {
        if (NPC.activeInHierarchy)
        {
            NPC.SetActive(false);
        }
        NewsPapers.SetActive(true);
        PageTitle.text = "Collected Documents Page";
    }

}
