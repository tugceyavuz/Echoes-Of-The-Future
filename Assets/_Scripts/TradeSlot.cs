using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics.Tracing;

public class TradeSlot : MonoBehaviour
{
    /// <summary>
    /// ///////////////////////////
    /// </summary>
    public string[] RequiredItemNames;
    private string actualItemName;
    public bool isHWIcluded;

    private void Update() {
        if (RequiredItemNames[0] == actualItemName || RequiredItemNames[1] == actualItemName)
        {
            isHWIcluded = true;
            this.enabled = false;
        }else{
            isHWIcluded = false;
        }
    }
}
