using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerPuzzle : MonoBehaviour
{
    public GameObject ComputerCanvas;
    public GameObject CodePanel;
    public GameObject SceneCanvas;
    private bool playerInRange;
    public bool isItTrade;

    public PlaceHW CompuerHW;

    public TextMeshProUGUI popup;


    private void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.C))
        {
            SceneCanvas.SetActive(false);
            ComputerCanvas.SetActive(true);
            CodePanel.SetActive(false);
            Time.timeScale = 0;
            if (CompuerHW.isHWIcluded)
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
}
