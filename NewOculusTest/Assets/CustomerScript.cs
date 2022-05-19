using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    //Get the game objects and components needed
    public CatCafeControl game;
    public Animator anim;
    public GameObject orderArea;
    public GameObject coinArea;
    public GameObject foodTray;
    public GameObject ownFoodTray;
    public GameObject coin;
    public AudioSource audio;
    public AudioClip DreadedCustomer;
    public bool left = true;
    public AudioClip CustomerGoingAway;
    // Start is called before the first frame update
    //Get the game objects and components needed
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        orderArea = GameObject.Find("Order Area");
        coinArea = GameObject.Find("CoinPlace");
        game = GameObject.Find("GameControl").GetComponent<CatCafeControl>();
        audio.PlayOneShot(DreadedCustomer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        //audio.PlayOneShot(DreadedCustomer);
    }
    //Destroys this Customer object when needed
    public void Leave()
    {
        Destroy(this.gameObject);
    }
    //Spawns the foodtray and uses it for later
    public void MakeAnOrder()
    {
        ownFoodTray = Instantiate(foodTray, orderArea.transform.position, orderArea.transform.rotation);
        //ownFoodTray.GetComponent<OrderProcess>().MakeOrder();
    }
    //Function for leaving animation with sound, giving coin, notifying the game, and destroying the customer in the end
    public void OrderDone()
    {
        game.CustomerLeft();
        Instantiate(coin, coinArea.transform.position, coinArea.transform.rotation);
        anim.Play("CustomerLeave");
        
        LeaveSound();
    }
    //Same as OrderDone, but used when the time is out and order is not complete without giving a coin
    public void GetOut()
    {
        game.CustomerLeft();
        anim.Play("CustomerLeave");
        LeaveSound();
    }
    //Turns the leave animation
    public void LeaveSound()
    {
        if (left)
        {
            left = false;
            audio.PlayOneShot(CustomerGoingAway, 0.1f);
        }
    }
}
