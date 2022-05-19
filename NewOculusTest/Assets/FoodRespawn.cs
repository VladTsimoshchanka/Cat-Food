using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRespawn : MonoBehaviour
{
    //Get the game objects and components needed
    public GameObject foodHolder;
    public GameObject foodConcept;
    public GameObject currentFood;
    public Transform foodTransform;
    float distance;
    public bool isTaken = false;
    // Start is called before the first frame update
    //Get the game objects and components needed
    void Start()
    {
        foodTransform = foodHolder.GetComponent<Transform>();
    }

    // Update is called once per frame
    //Checks the food status, and if it is taken, check whether to respawn it or not
    void Update()
    {
        if (currentFood.GetComponent<Rigidbody>().isKinematic)
        {
            isTaken = true;
        }
        if (isTaken)
        {
            distance = Vector3.Distance(currentFood.transform.position, foodHolder.transform.position);
            if(distance >= 0.8)
            {
                RestockFood();
                
            }
        }
        
    }
    //Respawns and updates food
    public void RestockFood()
    {
        currentFood = Instantiate(foodConcept, foodTransform.position, foodTransform.rotation);
        isTaken = false;
    }
}
