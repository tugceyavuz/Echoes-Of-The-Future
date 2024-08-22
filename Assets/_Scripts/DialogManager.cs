using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    private GameObject dialoguePanel;
    private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogManager instance;
    private GameObject canvas;

    private void Awake() 
    {
        instance = this;

        canvas = GameObject.Find("PanelsCanvas");
        dialoguePanel = canvas.transform.Find("DialogPanel").gameObject;

        GameObject DialogText = canvas.transform.Find("DialogPanel/TextPanel/DialogText").gameObject;
        dialogueText = DialogText.GetComponent<TextMeshProUGUI>();

        Transform parentTransform = canvas.transform.Find("DialogPanel/OptionsPanel");

        choices = new GameObject[parentTransform.childCount];

        // Loop through each child and assign to the array
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            choices[i] = parentTransform.GetChild(i).gameObject;
        }
    }

    public static DialogManager GetInstance() 
    {
        return instance;
    }

    private void Start() 
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // get all of the choices text 
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) 
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update() 
    {
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying) 
        {
            return;
        }
        if (currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) 
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Time.timeScale = 0; // Pause the game

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode() 
    {
        yield return new WaitForSeconds(0.1f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory() 
    {
        if (currentStory.canContinue) 
        {
            // set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
            // display choices, if any, for this dialogue line
            DisplayChoices();
        }
        else 
        {
            Time.timeScale = 1; // Resume the game
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices() 
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

}
