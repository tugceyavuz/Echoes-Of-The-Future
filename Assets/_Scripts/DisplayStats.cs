using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStats : MonoBehaviour
{
    public TextMeshProUGUI efficiencyScore;
    public TextMeshProUGUI healtScore;
    public TextMeshProUGUI hungerScore;
    public TextMeshProUGUI thirstScore;
    public TextMeshProUGUI playTime;

    private PlayerEndingStats playerEndingStats;
    private PlayerStatsManager playerStatsManager;

    void Awake()
    {
        playerEndingStats = GameObject.Find("PlayerEndingStats").GetComponent<PlayerEndingStats>();
        playerStatsManager = GameObject.Find("PlayerEndingStats").GetComponent<PlayerStatsManager>();
    }

    void Start()
    {
        efficiencyScore.text = playerEndingStats.CalculateScore().ToString();
        playTime.text = playerEndingStats.GetTotalTime().ToString();
        healtScore.text = playerStatsManager.currentHealth.ToString();
        hungerScore.text = playerStatsManager.currentHunger.ToString();
        thirstScore.text = playerStatsManager.currentThirst.ToString();
    }
}
