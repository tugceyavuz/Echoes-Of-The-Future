using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class NextLvlLoader : MonoBehaviour
{
    // The name or index of the level to load
    public string levelToLoad;

    // This method is called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider's tag is "Player"
        if (other.CompareTag("Player"))
        {
            // Load the specified level
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
