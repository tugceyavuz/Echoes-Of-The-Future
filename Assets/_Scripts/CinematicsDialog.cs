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
        if (SceneManager.GetActiveScene().name == "LVL6")
        {
            if(GameObject.Find("Canvas") != null) Destroy(GameObject.Find("Canvas"));
            Destroy(GameObject.Find("Player"));
        }
    }

    private void Update() {
        if (!finished)
        {
            dialogManager.EnterDialogueMode(InkJSON, false);
            finished = true;
        }
        if(!dialogManager.dialogueIsPlaying){
            StartCoroutine(LoadNextLVL());
        }
    }


    private IEnumerator LoadNextLVL() 
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(levelToLoad);
    }

    
}
