using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int IQ;
    public int EQ;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        IQ = 100;
        EQ = 100;
    }

    public void IncreaseIQ(int amount)
    {
        IQ += amount;
    }

    public bool SpendIQ(int amount)
    {
        if (amount <= IQ)
        {
            IQ -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enuf");
            return false;
        }
    }

    // decrease eq ingame
    public void DecreaseEQ(int amount)
    {
        EQ -= amount;

        Debug.Log("Current EQ: " + EQ);

        if (EQ == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
