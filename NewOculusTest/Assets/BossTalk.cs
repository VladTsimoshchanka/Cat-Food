using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossTalk : MonoBehaviour
{
    //Get the game objects and components needed
    public bool passed = false;
    public Text CatTalk;
    // Start is called before the first frame update
    //Get the game objects and components needed
    //Also, sets the scenario for the boss talk depending on the coins stored and coins stashed
    void Start()
    {
        CatTalk = GameObject.FindGameObjectWithTag("BossText").GetComponent<Text>();
        if(MoneyPlace.CoinsStored >= MoneyPlace.CoinsStoredThreshold && MoneyPlace.CoinsStashed < MoneyPlace.CoinsStashedThreshold)
        {
            CatTalk.text = "Well done, human. You will be graced with another work day. \n Press A or X to begin work.";
            MoneyPlace.SetCoins(0);
            MoneyPlace.AddThreshold();
            passed = true;
        }
        else if(MoneyPlace.CoinsStashed >= MoneyPlace.CoinsStashedThreshold)
        {
            CatTalk.text = "The cats are gone. I spare you. \n Press A or X to escape.";
            passed = false;
        }
        else
        {
            CatTalk.text = "You have frustrated us. \n Press A or X to become a part of us.";
            passed = false;
        }

    }

    // Update is called once per frame
    //Used to switch the scenes
    void Update()
    {
        if (passed)
        {
            if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
            {
                SceneManager.LoadScene(2);
            }
            
        }
        else
        {
            if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
            {
                Application.Quit();
            }
        }
    }

    
}
