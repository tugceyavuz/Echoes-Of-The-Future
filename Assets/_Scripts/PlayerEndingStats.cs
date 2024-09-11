using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndingStats : MonoBehaviour
{
    public float palyerOverallScore;
    public float TotalTime { get; private set; }
    void Awake()
    {
        palyerOverallScore = 0;
        TotalTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;
    }

    public float CalculateScore()
    {
        float average = 100 * palyerOverallScore / 300;
        return Mathf.Round(average * 100f) / 100f;
    }

    public float GetTotalTime()
    {
        // Convert seconds to minutes
        float totalTimeInMinutes = TotalTime / 60f;
        
        // Round to 2 decimal places
        return Mathf.Round(totalTimeInMinutes * 100f) / 100f;
    }
}
