using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using TMPro;
using System;
using UnityEngine.UI;

public class NextLvlLoader : MonoBehaviour
{
    // The name or index of the level to load
    public string levelToLoad;
    private bool isPlayerInRange;
    private TextMeshProUGUI Text;
    private GameObject PopUpPanel;
    private ComputerPuzzle Puzzle;
    private bool isPuzzleDone;

    private void Awake() {
        Text = GameObject.Find("PanelsCanvas").transform.Find("popUp").gameObject.GetComponent<TextMeshProUGUI>();
        PopUpPanel = GameObject.Find("PanelsCanvas").transform.Find("PopUpPanel").gameObject;
        PopUpPanel.SetActive(false);

        if(SceneManager.GetActiveScene().name != "LVL2") 
        {    
            Puzzle = GameObject.Find("Computer").GetComponent<ComputerPuzzle>();
            isPuzzleDone = Puzzle.done;
        }else isPuzzleDone = true;
    }

    void Update()
    {
        // Check for the F key press when the player is in range
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if(SceneManager.GetActiveScene().name != "LVL2") isPuzzleDone = Puzzle.done;
            PopUpPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && PopUpPanel.activeInHierarchy)
        {
            Time.timeScale = 1;
            PopUpPanel.SetActive(false);
        }
    }

    public void ClosePopUp()
    {
        Time.timeScale = 1;
        PopUpPanel.SetActive(false);
    }

    public Animator transitionAnim;


    public void LoadNextLVL()
    {
        if(isPuzzleDone) StartCoroutine(LoadNext());
    }

    private IEnumerator LoadNext() 
    {
        Time.timeScale = 1;
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(levelToLoad);
    }

    // This method is called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider's tag is "Player"
        if (other.CompareTag("Player"))
        {
            // Load the specified level
            isPlayerInRange = true;
            Text.text = "Press F to read";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collider's tag is "Player"
        if (other.CompareTag("Player"))
        {
            // Load the specified level
            isPlayerInRange = false;
            Text.text = "";
        }
    }
}
