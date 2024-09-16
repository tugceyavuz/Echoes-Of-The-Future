using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    private void Start() {
        if (GameObject.Find("Player") != null)
        {
            Destroy(GameObject.Find("Player"));
        }
        if (GameObject.Find("PlayerEndingStats") != null && SceneManager.GetActiveScene().name != "Ending")
        {
            Destroy(GameObject.Find("PlayerEndingStats"));
        }
        if(GameObject.Find("Canvas") != null) Destroy(GameObject.Find("Canvas"));
    }
}
