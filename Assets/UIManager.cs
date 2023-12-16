using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager main;


    private bool isHoweringUI;

    private void Awake()
    {
        main = this;
    }

    public void SetHoveringState(bool state)
    {
        isHoweringUI = state;
    }

    public bool IsHoweringUI()
    {
        return isHoweringUI;
    }
}
