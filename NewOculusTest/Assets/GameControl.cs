using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


//I have changed this script to work as a timer and music changer.
public class GameControl : MonoBehaviour
{
    public Text finalText;
    public Text taskText;
    public int tasks = 3;
    public bool rocksSet = false;
    public bool catSet = false;
    public bool lanternsSet = false;
    public bool isZen = false;
    public UnityEvent omedetou;
    public float time = 30f;
    public float minutes = 0f;
    public float seconds = 0f;
    public string minutesString = "";
    public string secondsString = "";
    //Is time still going
    public bool stillGoing = true;
    //Used to change their colors
    public Light Sun;
    public Light Moon;

    public bool endGame = true;
    // Start is called before the first frame update
    void Start()
    {
        finalText.text = "This is not a warning";
        taskText.text = "Zen Garden detonation in";
    }

    // The time is calculated and displayed here
    //If time is 0, the game becomes stygian and the player needs to press X or A to quit the game as written in the text
    void Update()
    {
        //If time is less than or equal to 0
        if (stillGoing)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                stillGoing = false;
            }
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

            taskText.text = "Zen Garden detonation in " + minutesString + ":" + secondsString;
        }
        //If the game ended
        else
        {
            EndOfTheWorld();
            Sun.color = Color.red;
            Moon.color = Color.red;
            if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
            {
                Application.Quit();
            }
        }
    }

    public void SetRocks()
    {
        if(rocksSet == false)
        {
            rocksSet = true;
            tasks -= 1;
            UpdateText();
        }
    }
    //End screen function
    public void EndOfTheWorld()
    {
        if (endGame)
        {
            finalText.text = "This is it, Zen Garden is no more";
            taskText.text = "Press A or X or leave";
            omedetou.Invoke();
            GameObject.Find("Music").GetComponent<AudioSource>().enabled = !GameObject.Find("Music").GetComponent<AudioSource>().enabled;
            
            endGame = false;
        }
        
    }
    public void SetLanterns()
    {
        if (lanternsSet == false)
        {
            lanternsSet = true;
            tasks -= 1;
            UpdateText();
        }
    }

    public void SetCat()
    {
        if (catSet == false)
        {
            catSet = true;
            tasks -= 1;
            UpdateText();
        }
    }

    public void UpdateText()
    {
        /*
        taskText.text = "Tasks until zen level: " + tasks.ToString();
        if (tasks == 0)
        {
            finalText.text = "You have seccessfully reached Zen level. お目出度う";
            taskText.text = "Zen level. お目出度う";
            omedetou.Invoke();
            GameObject.Find("Music").GetComponent<AudioSource>().enabled = !GameObject.Find("Music").GetComponent<AudioSource>().enabled;
        }
        */
    }

    

    


}
