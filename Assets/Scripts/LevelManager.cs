using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int EQ;
    public int IQ;
    
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {

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
        // if enemy EQ deduct from original EQ is less than 0 (eg: -5), set value to 0
        // else, deduct normally
        if ((EQ -= amount) < 0)
        {
            EQ = 0;
        }
        else 
        {
            EQ -= amount;
        }

        Debug.Log("Current EQ: " + EQ);

        if (EQ == 0)
        {
            Debug.Log("Game Over");
            GameOverMenu.isGameOver = true;
        }
    }
}
