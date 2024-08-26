using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicsDialog : MonoBehaviour
{
    [SerializeField] private TextAsset InkJSON;
    [SerializeField] private DialogManager dialogManager;
    public bool finished;
    public string levelToLoad;
    public Animator transitionAnim;

    private void Start() {
    }

    private void Update() {
        if (!finished)
        {
            dialogManager.EnterDialogueMode(InkJSON);
            finished = true;
        }
        if(!dialogManager.dialogueIsPlaying){
            StartCoroutine(LoadNextLVL());
        }
    }


    private IEnumerator LoadNextLVL() 
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelToLoad);
    }

    
}