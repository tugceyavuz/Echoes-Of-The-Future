using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Parsed;

public class ComputerPuzzle : MonoBehaviour
{
    public GameObject ComputerCanvas;
    public GameObject CodePanel;
    public GameObject SceneCanvas;
    private bool playerInRange;
    public bool option1;
    public bool option2;

    public PlaceHW CompuerHW;

    public TextMeshProUGUI popup;
    public PlaceHW placedHW;
    public string[] HWNames;

    private void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.C))
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
            popup.text = "Press C to interact";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            popup.text = "";
        }
    }
    
    public PlayerMovement player;
    public GameObject FinishScreen;
    private bool done;

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
        
        player.overallScore += (hwScore + swScore )/ 2;
        done = true;
        Debug.Log(player.overallScore);
    }
}
