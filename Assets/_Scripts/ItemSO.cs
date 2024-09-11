using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public int amountToChangeStat;
    public StatToChange statToChange = new();

    public enum StatToChange{
        none, health, hunger, thirst
    };
    
    public bool UseItem(){
        PlayerStatsManager playerStats = GameObject.Find("PlayerEndingStats").GetComponent<PlayerStatsManager>();
        switch (statToChange)
        {
            case StatToChange.health:
                if (playerStats.currentHealth >= playerStats.maxHealth && (amountToChangeStat >= 0))
                {
                    return false;
                }
                playerStats.ChangeHealth(amountToChangeStat);
            break;
            case StatToChange.hunger:
                if (playerStats.currentHunger >= playerStats.maxHunger && (amountToChangeStat >= 0))
                {
                    return false;
                }
                playerStats.ChangeHunger(amountToChangeStat);
            break;
            case StatToChange.thirst:
                if (playerStats.currentThirst >= playerStats.maxThirst && (amountToChangeStat >= 0))
                {
                    return false;
                }
                playerStats.ChangeThirst(amountToChangeStat);
            break;       
        }
        return true;
    }
}
