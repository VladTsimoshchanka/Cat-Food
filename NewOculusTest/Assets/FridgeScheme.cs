using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FridgeScheme : MonoBehaviour
{
    //Get the game objects and components needed
    public Text FridgeTalk;
    public int coinCount;
    // Start is called before the first frame update
    //Get the game objects and components needed
    void Start()
    {
        coinCount = MoneyPlace.CoinsStashed;
    }
    //If player gives it coin, take it, destroy it, and update the coins stashed
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Coin")
        {
            coinCount++;
            MoneyPlace.CoinsStashed = coinCount;
            FridgeTalk.text = "Coins stashed: " + coinCount.ToString();
            

            Destroy(collision.gameObject);


        }





    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
