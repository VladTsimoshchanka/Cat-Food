using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRocks : MonoBehaviour
{

    private bool wasGrabbed = false;

    public GameObject game;
    private OVRGrabbable grabScript;
    // Start is called before the first frame update
    void Start()
    {
        grabScript = GetComponent<OVRGrabbable>();
       // game = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            //GetComponent<Rigidbody>().isKinematic = false;
            wasGrabbed = true;
            game.GetComponent<GameControl>().SetRocks();
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (wasGrabbed && collision.gameObject.tag == "Rock")
        {
            wasGrabbed = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            
        }



    }
}
