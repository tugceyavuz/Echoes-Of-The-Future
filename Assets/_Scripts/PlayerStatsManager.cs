using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsManager : MonoBehaviour
{
    // Player stats
    [SerializeField]
    public int maxHealth = 100;
    [SerializeField]
    public int maxHunger = 100;
    [SerializeField]
    public int maxThirst = 100;

    public int currentHealth;
    public int currentHunger;
    public int currentThirst;

    // UI elements to display stats
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;

    // Time intervals for hunger and thirst decrease
    public float hungerDecreaseInterval = 5f; // in seconds
    public float thirstDecreaseInterval = 3f; // in seconds

    private void Start()
    {
        // Initialize stats
        currentHealth = maxHealth;
        currentHunger = 10;
        currentThirst = maxThirst;

        // Update UI
        /*UpdateHealthUI();
        UpdateHungerUI();
        UpdateThirstUI();*/

        // Start coroutines to decrease hunger and thirst over time
        StartCoroutine(DecreaseHungerOverTime());
        StartCoroutine(DecreaseThirstOverTime());
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //UpdateHealthUI();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            // Handle player death (e.g., respawn, game over, etc.)
            Debug.Log("Player is dead.");
        }
    }

    public void ChangeHunger(int amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        //UpdateHungerUI();

        Debug.Log(currentHunger);
        // Check if hunger is at zero and apply health penalty
        if (currentHunger <= 0)
        {
            ChangeHealth(-5); //  penalty for starvation
        }
    }

    public void ChangeThirst(int amount)
    {
        currentThirst += amount;
        currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
        //UpdateThirstUI();

        // Check if thirst is at zero and apply health penalty
        if (currentThirst <= 0)
        {
            ChangeHealth(-5); //  penalty for dehydration
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    private void UpdateHungerUI()
    {
        if (hungerText != null)
        {
            hungerText.text = "Hunger: " + currentHunger.ToString();
        }
    }

    private void UpdateThirstUI()
    {
        if (thirstText != null)
        {
            thirstText.text = "Thirst: " + currentThirst.ToString();
        }
    }

    private IEnumerator DecreaseHungerOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(hungerDecreaseInterval);
            ChangeHunger(-1);
        }
    }

    private IEnumerator DecreaseThirstOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(thirstDecreaseInterval);
            ChangeThirst(-1);
        }
    }
}
