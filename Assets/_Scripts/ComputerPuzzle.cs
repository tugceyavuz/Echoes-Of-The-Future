using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Parsed;

public class ComputerPuzzle : MonoBehaviour
{
    public GameObject ComputerCanvas;
    public GameObject CodePanel;
    private GameObject SceneCanvas;
    private bool playerInRange;
    public bool option1;
    public bool option2;

    public PlaceHW CompuerHW;

    private TextMeshProUGUI popup;
    public PlaceHW placedHW;
    public string[] HWNames;

    private PlayerEndingStats playerEndingStats;
    public GameObject FinishScreen;
    public bool done;
    
    private void Awake() {
        SceneCanvas = GameObject.Find("Canvas");
        GameObject PopUp = GameObject.Find("Canvas").transform.Find("popUp").gameObject;
        popup = PopUp.GetComponent<TextMeshProUGUI>();

        playerEndingStats = GameObject.Find("PlayerEndingStats").GetComponent<PlayerEndingStats>();
    }

    private void Start() {
        ComputerCanvas.SetActive(false);
        CodePanel.SetActive(false);
    }

    private void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            SceneCanvas.SetActive(false);
            ComputerCanvas.SetActive(true);
            CodePanel.SetActive(false);
            Time.timeScale = 0;
            if (CompuerHW.isHWIcluded && !done)
            {
                DisplayCode();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 1;
            SceneCanvas.SetActive(true);
            ComputerCanvas.SetActive(false);
        }
    }

    private void DisplayCode(){
        CodePanel.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            popup.text = "Press F to interact";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            popup.text = "";
        }
    }

    public void Option(int name){
        if (name == 1)
        {
            option1 = true;
        }else option2 = true;
        
        CodePanel.SetActive(false);
        FinishScreen.SetActive(true);
        CalculateScore();
    }

    private void CalculateScore(){

        //HW
        float hwScore = 0;
        if (placedHW.usedItem == HWNames[0])
        {
            hwScore = 100;
        }

        //SW
        float swScore = 0;
        if (option2)
        {
            swScore = 100;
        }
        
        playerEndingStats.palyerOverallScore += (hwScore + swScore )/ 2;
        done = true;
        Debug.Log(playerEndingStats.palyerOverallScore);
    }
}
