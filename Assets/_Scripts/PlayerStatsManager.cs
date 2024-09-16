using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private TextMeshProUGUI healthText;
    private TextMeshProUGUI hungerText;
    private TextMeshProUGUI thirstText;

    private GameObject HealthWarning;
    private GameObject HungerWarning;
    private GameObject ThirstWarning;

    private Image healthBar;
    private Image hungerBar;
    private Image thirstBar;

    // Time intervals for hunger and thirst decrease
    private float hungerDecreaseInterval = 5f; // in seconds
    private float thirstDecreaseInterval = 10f; // in seconds

    private GameObject canvas;

    private void Awake() {
        canvas = GameObject.Find("Canvas");

        GameObject health = canvas.transform.Find("StatsPanel/HealthPanel/NumberPanel/HealthPointsText").gameObject;
        healthText = health.GetComponent<TextMeshProUGUI>();
        GameObject Ihealth = canvas.transform.Find("StatsPanel/HealthPanel/BarPanel/Image").gameObject;
        healthBar = Ihealth.GetComponent<Image>();
        HealthWarning = GameObject.Find("Canvas/StatsPanel/HealthPanel/WarningImage");

        GameObject hunger = canvas.transform.Find("StatsPanel/HungerPanel/TextPanel/HungerPointsText").gameObject;
        hungerText = hunger.GetComponent<TextMeshProUGUI>();
        GameObject Ihunger = canvas.transform.Find("StatsPanel/HungerPanel/BarPanel/Image").gameObject;
        hungerBar = Ihunger.GetComponent<Image>();
        HungerWarning = GameObject.Find("Canvas/StatsPanel/HungerPanel/WarningImage");

        GameObject thirst = canvas.transform.Find("StatsPanel/ThirstPanel/TextPanel/ThirstPointsText").gameObject;
        thirstText = thirst.GetComponent<TextMeshProUGUI>();
        GameObject Ithirst = canvas.transform.Find("StatsPanel/ThirstPanel/BarPanel/Image").gameObject;
        thirstBar = Ithirst.GetComponent<Image>();
        ThirstWarning = GameObject.Find("Canvas/StatsPanel/ThirstPanel/WarningImage");
    }
    private void Start()
    {
        // Initialize stats
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;

        HealthWarning.SetActive(false);
        HungerWarning.SetActive(false);
        ThirstWarning.SetActive(false);

        // Update UI
        UpdateHealthUI();
        UpdateHungerUI();
        UpdateThirstUI();

        // Start coroutines to decrease hunger and thirst over time
        StartCoroutine(DecreaseHungerOverTime());
        StartCoroutine(DecreaseThirstOverTime());
    }

    private void Update() {
        if(GameObject.Find("Canvas") != null){
            if (currentHealth <= 20)
            {
                HealthWarning.SetActive(true);
            }else HealthWarning.SetActive(false);

            if (currentHunger <= 20)
            {
                HungerWarning.SetActive(true);
            }else HungerWarning.SetActive(false);

            if (currentThirst <= 20)
            {
                ThirstWarning.SetActive(true);
            }else ThirstWarning.SetActive(false);
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            if (canvas != null) {canvas.transform.Find("GameOverPanel").gameObject.SetActive(true); Time.timeScale = 0;}
            Debug.Log("Player is dead.");
        }
    }

    public void LoadStatsLevel(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Ending");
    }
    public void ExitLevel(){
        Time.timeScale = 1;
        Application.Quit();
    }

    public void ChangeHunger(int amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        UpdateHungerUI();

        // Check if hunger is at zero and apply health penalty
        if (currentHunger <= 0)
        {
            ChangeHealth(-1); //  penalty for starvation
        }
    }

    public void ChangeThirst(int amount)
    {
        currentThirst += amount;
        currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
        UpdateThirstUI();

        // Check if thirst is at zero and apply health penalty
        if (currentThirst <= 0)
        {
            ChangeHealth(-1); //  penalty for dehydration
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
        if (healthBar != null) healthBar.fillAmount = currentHealth / 100f;
    }

    private void UpdateHungerUI()
    {
        if (hungerText != null)
        {
            hungerText.text = currentHunger.ToString();
        }
        if (hungerBar != null) hungerBar.fillAmount = currentHunger / 100f;
    }

    private void UpdateThirstUI()
    {
        if (thirstText != null)
        {
            thirstText.text = currentThirst.ToString();
        }
        if (thirstBar != null) thirstBar.fillAmount = currentThirst / 100f;
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
