using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class CatLord : MonoBehaviour
{
    //Get the game objects and components needed
    public Text CatTalk;

    public UnityEvent meow;
    int coinCount;
    // Start is called before the first frame update
    //Get the game objects and components needed
    void Start()
    {
        coinCount = MoneyPlace.CoinsStored;
        CatTalk = GameObject.Find("Coins").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Updates the number of coins stored
    public void SetCoins(int i)
    {
        coinCount = i;
        MoneyPlace.CoinsStored = coinCount;
    }
    //Check whether it is a coin, take it away, and increase coins stored.

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCount++;
            MoneyPlace.CoinsStored = coinCount;
            CatTalk.text = "Coins stored: " + coinCount.ToString();
            meow.Invoke();
            
            
          
            
        }

        



    }
}
