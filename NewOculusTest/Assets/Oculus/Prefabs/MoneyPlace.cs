using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPlace : MonoBehaviour
{
    //Get the game objects and components needed
    public static bool CoinsPassed = false;
    public static int CoinsStored = 0;
    public static int CoinsStashed = 0;
    public static int CoinsStoredThreshold = 3;
    public static int CoinsStashedThreshold = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Updates coins stored
    public static void SetCoins(int i)
    {
        CoinsStored = i;
        if(CoinsStored >= CoinsStoredThreshold)
        {
            CoinsPassed = true;
        }
        else
        {
            CoinsPassed = false;
        }
    }
    //Changes stored coins requirement
    public static void SetThreshold(int i)
    {
        CoinsStoredThreshold = i;
    }
    //Increments stored coin threshold by one
    public static void AddThreshold()
    {
        CoinsStoredThreshold++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
