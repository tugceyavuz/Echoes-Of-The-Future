using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public Animator transitionAnim;

    public void LoadNextLVL()
    {
        StartCoroutine(LoadNext());
    }

    private IEnumerator LoadNext() 
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(levelToLoad);
    }
    // Function to exit the game
    public void ExitGame()
    {
        // This will only work when the game is built and running as an executable
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}
