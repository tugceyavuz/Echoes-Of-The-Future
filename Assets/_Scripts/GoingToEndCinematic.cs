using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingToEndCinematic : MonoBehaviour
{
    private GameObject canvas;
    public GameObject DialogPanel;
    private bool isPuzzleDone;
    private ComputerPuzzle Puzzle;
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private TextAsset InkJSON;
    public bool finished;
    public Animator transitionAnim;

    void Awake()
    {
        canvas = GameObject.Find("Canvas");   
        Puzzle = GameObject.Find("Computer").GetComponent<ComputerPuzzle>();
        isPuzzleDone = Puzzle.done;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPuzzleDone)
        {
            Destroy(GameObject.Find("Canvas"));
            if (!finished)
            {
                finished = true;
                dialogManager.EnterDialogueMode(InkJSON, true);
            }
            if(!dialogManager.dialogueIsPlaying){
                StartCoroutine(LoadNextLVL());
            }
        }else isPuzzleDone = Puzzle.done;
    }

    private IEnumerator LoadNextLVL() 
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("LVL6");
    }
}
