using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OrderProcess : MonoBehaviour
{

    public GameObject customer;
    public List<string> AllFoods = new List<string> { "Burger", "Fry", "Maki Maki Roll", "Onigiri" };
    public List<string> possibleFoods = new List<string> { "Burger", "Fry", "Maki Maki Roll", "Onigiri" };
    public List<string> storedFoods = new List<string> ();
    public List<string> orderedFoods = new List<string>();
    public GameObject[] orderText;
    public bool testingOrder = false;
    public bool orderMade = false;

    public GameObject Place1;
    public GameObject Place1Food;
    public bool Place1Empty = true;

    public GameObject Place2;
    public GameObject Place2Food;
    public bool Place2Empty = true;

    public GameObject Place3;
    public GameObject Place3Food;
    public bool Place3Empty = true;

    public GameObject Place4;
    public GameObject Place4Food;
    public bool Place4Empty = true;

   
    //public UnityEvent meow;
    // Start is called before the first frame update
    void Start()
    {
        customer = GameObject.FindWithTag("Customer");
        orderText = GameObject.FindGameObjectsWithTag("OrderText");
        //Debug.Log("here");
        
            MakeOrder();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Place1Empty)
        {
            if (Place1Food.GetComponent<Rigidbody>().isKinematic)
            {
                Place1Empty = true;
                storedFoods.Remove((string)Place1Food.tag);
                orderedFoods.Add((string)Place1Food.tag);
                foreach (GameObject text in orderText)
                {
                    text.GetComponent<Text>().text = "";
                }
                foreach (string food in orderedFoods)
                {
                    foreach (GameObject text in orderText)
                    {
                        text.GetComponent<Text>().text += food + "\n" + "\n";
                    }
                }
                Place1Food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Place1Food = null;

            }
        }
        if (!Place2Empty)
        {
            if (Place2Food.GetComponent<Rigidbody>().isKinematic)
            {
                Place2Empty = true;
                storedFoods.Remove((string)Place2Food.tag);
                orderedFoods.Add((string)Place2Food.tag);
                foreach (GameObject text in orderText)
                {
                    text.GetComponent<Text>().text = "";
                }
                foreach (string food in orderedFoods)
                {
                    foreach (GameObject text in orderText)
                    {
                        text.GetComponent<Text>().text += food + "\n" + "\n";
                    }
                }
                Place1Food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Place2Food = null;

            }
        }
        if (!Place3Empty)
        {
            if (Place3Food.GetComponent<Rigidbody>().isKinematic)
            {
                Place3Empty = true;
                storedFoods.Remove((string)Place3Food.tag);
                orderedFoods.Add((string)Place3Food.tag);
                foreach (GameObject text in orderText)
                {
                    text.GetComponent<Text>().text = "";
                }
                foreach (string food in orderedFoods)
                {
                    foreach (GameObject text in orderText)
                    {
                        text.GetComponent<Text>().text += food + "\n" + "\n";
                    }
                }
                Place1Food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Place3Food = null;

            }
        }
        if (!Place4Empty)
        {
            if (Place4Food.GetComponent<Rigidbody>().isKinematic)
            {
                Place4Empty = true;
                storedFoods.Remove((string)Place4Food.tag);
                orderedFoods.Add((string)Place4Food.tag);
                foreach (GameObject text in orderText)
                {
                    text.GetComponent<Text>().text = "";
                }
                foreach (string food in orderedFoods)
                {
                    foreach (GameObject text in orderText)
                    {
                        text.GetComponent<Text>().text += food + "\n" + "\n";
                    }
                }
                Place4Food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Place4Food = null;

            }
        }
        if(orderedFoods.Count == 0 || testingOrder)
        {
            foreach (GameObject text in orderText)
            {
                text.GetComponent<Text>().text = "No new orders";
            }
            if (Place1Food != null)
            {
                Place1Food.transform.SetParent(this.transform);
            }
            
            if (Place2Food != null)
            {
                Place2Food.transform.SetParent(this.transform);
            }
            if (Place3Food != null)
            {
                Place3Food.transform.SetParent(this.transform);
            }

            if (Place4Food != null)
            {
                Place4Food.transform.SetParent(this.transform);
            }
            customer.GetComponent<CustomerScript>().OrderDone();
            Destroy(gameObject);
        }
    }
    public void ToHellWithThisOrder()
    {
        foreach (GameObject text in orderText)
        {
            text.GetComponent<Text>().text = "No new orders";
        }
        if (Place1Food != null)
        {
            Place1Food.transform.SetParent(this.transform);
        }

        if (Place2Food != null)
        {
            Place2Food.transform.SetParent(this.transform);
        }
        if (Place3Food != null)
        {
            Place3Food.transform.SetParent(this.transform);
        }

        if (Place4Food != null)
        {
            Place4Food.transform.SetParent(this.transform);
        }
        
        Destroy(gameObject);
    }    
    void OnCollisionEnter(Collision collision)
    {
        
        if (orderedFoods.Contains((string)collision.gameObject.tag))
        {
        for (int i = 0; i < orderedFoods.Count; i++)
        {
            
           // Debug.Log(orderedFoods[i]);
            
            if (collision.gameObject.CompareTag(orderedFoods[i]))
            {
                
                orderedFoods.Remove(orderedFoods[i]);
                foreach (GameObject text in orderText)
                {

                    text.GetComponent<Text>().text = text.GetComponent<Text>().text.Remove(text.GetComponent<Text>().text.IndexOf(collision.gameObject.tag), collision.gameObject.tag.Length);



                }
                    //Destroy(collision.gameObject);
                    if (storedFoods.Contains((string)collision.gameObject.tag))
                    {
                        Debug.Log("Has this food: " + collision.gameObject.tag);
                    }


                        if (Place1Empty && !storedFoods.Contains((string)collision.gameObject.tag))
                        {
                            Place1Empty = false;
                            Place1Food = collision.gameObject;
                        collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                        collision.gameObject.transform.position = Place1.transform.position;
                            collision.gameObject.transform.rotation = Place1.transform.rotation;
                        
                        storedFoods.Add((string)collision.gameObject.tag);
                            Debug.Log(storedFoods[0]);

                        }
                        else if (Place2Empty && !storedFoods.Contains((string)collision.gameObject.tag))
                        {
                            Place2Empty = false;
                            Place2Food = collision.gameObject;
                            collision.gameObject.transform.position = Place2.transform.position;
                            collision.gameObject.transform.rotation = Place2.transform.rotation;
                        collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                        storedFoods.Add((string)collision.gameObject.tag);
                            Debug.Log(storedFoods[1]);

                        }
                        else if (Place3Empty && !storedFoods.Contains((string)collision.gameObject.tag))
                        {
                            Place3Empty = false;
                            Place3Food = collision.gameObject;
                            collision.gameObject.transform.position = Place3.transform.position;
                            collision.gameObject.transform.rotation = Place3.transform.rotation;
                        collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                        storedFoods.Add((string)collision.gameObject.tag);
                            Debug.Log("Place3");

                        }
                        else if (Place4Empty && !storedFoods.Contains((string)collision.gameObject.tag))
                        {
                            Place4Empty = false;
                            Place4Food = collision.gameObject;
                            collision.gameObject.transform.position = Place4.transform.position;
                            collision.gameObject.transform.rotation = Place4.transform.rotation;
                        collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                        storedFoods.Add((string)collision.gameObject.tag);
                            Debug.Log("Place4");

                        }
                    
                    break;
            }

        }









        }




    }
    public void CheckFood(Collision collision)
    {
        
    }
    public void MakeOrder()
    {
        int randomFood;
        int threshold = Random.Range(1, possibleFoods.Count + 1);
        for (int i = 0; i < threshold; i++)
        {
            randomFood = Random.Range(0, possibleFoods.Count);
            orderedFoods.Add(possibleFoods[randomFood]);
            possibleFoods.RemoveAt(randomFood);
        }
        foreach(GameObject text in orderText)
        {
            text.GetComponent<Text>().text = "";
         }
        foreach(string food in orderedFoods)
        {
            foreach(GameObject text in orderText)
            {
                text.GetComponent<Text>().text += food + "\n" + "\n";
            }
        }
        orderMade = true;
    }
}
