using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CatCafeControl : MonoBehaviour
{
    //Get the game objects and components needed
    public Text CoinsNeeded;
    public float minutes = 0f;
    public float seconds = 0f;
    public string minutesString = "";
    public string secondsString = "";
    public float customerInterim = 5f;
    public GameObject CustomerEntry;
    public float time = 90f;
    public GameObject customer;
    public GameObject currentCustomer;
    public Text shiftText;
    public bool isThereCustomer = true;
    public bool open = true;
    // Start is called before the first frame update
    //Get the game objects and components needed
    void Start()
    {
        CustomerEntry = GameObject.Find("CustomerEntry");
        CoinsNeeded = GameObject.FindGameObjectWithTag("CoinsNeeded").GetComponent<Text>();
        CoinsNeeded.text = "Coins needed today: " + MoneyPlace.CoinsStoredThreshold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks whether there is a customer and whether the place is open still
        //If not, count until spawn of a new customer and spawn it
        if (!isThereCustomer && open)
        {
            customerInterim -= Time.deltaTime;
            if(customerInterim <= 0)
            {
                isThereCustomer = true;
                customerInterim = 5f;
                PlaceCustomer();
            }
        }
        //Counts remaining time
        if(time > 0f)
        {
            
            time -= Time.deltaTime;
            minutes = Mathf.Floor(time / 60);

            seconds = Mathf.RoundToInt(time % 60);

            if (minutes < 10)
            {
                minutesString = "0" + minutes.ToString();
            }
            else
            {
                minutesString = minutes.ToString();
            }
            if (seconds < 10)
            {
                secondsString = "0" + Mathf.RoundToInt(seconds).ToString();
            }
            else
            {
                secondsString = seconds.ToString();
            }

            shiftText.text = "Shift ends in: " + minutesString + ":" + secondsString;
        }
        //Closes the place with customer leaving, order destroyed, and the next scene choice based on the coins stashed
        else
        {
            open = false;
            if (GameObject.FindWithTag("Customer") != null){
                GameObject.FindWithTag("Customer").GetComponent<CustomerScript>().GetOut();

            }
            if(GameObject.FindWithTag("FoodTray") != null)
            {
                GameObject.FindWithTag("FoodTray").GetComponent<OrderProcess>().ToHellWithThisOrder();
            }
            shiftText.text = "Shift ended. Press A or X to move on.";
            if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
            {
                if(MoneyPlace.CoinsStashed >= MoneyPlace.CoinsStashedThreshold)
                {
                    SceneManager.LoadScene(3);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
                
            }
        }
    }
    //Spawns customer where needed
    public void PlaceCustomer()
    {
        Instantiate(customer, CustomerEntry.transform.position, CustomerEntry.transform.rotation);
    }
    //Updates customer status
    public void CustomerLeft()
    {
        isThereCustomer = false;
    }
}
