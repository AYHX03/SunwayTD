using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHealth : MonoBehaviour
{

    [Header("References")]
    [SerializeField] TextMeshProUGUI healthUI;
    [SerializeField] TextMeshProUGUI currencyUI;

    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.IQ.ToString();
        healthUI.text = LevelManager.main.EQ.ToString();

    }

 
}
