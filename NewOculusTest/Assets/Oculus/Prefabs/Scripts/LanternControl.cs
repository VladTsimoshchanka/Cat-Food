using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LanternControl : MonoBehaviour
{
    public GameObject game;

    private bool wasGrabbed = false;
    public UnityEvent OnRelease;
    public float floatStrength = 5f;
    private OVRGrabbable grabScript;
    public Vector3 upwards;
    public float height = 0.0f;
    public bool lightUp = true;
    // Start is called before the first frame update
    void Start()
    {
        grabScript = GetComponent<OVRGrabbable>();
        //game = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Rigidbody>().isKinematic)
        {
            wasGrabbed = true;
          

        }

        if (wasGrabbed)
        {
            if (lightUp)
            {
                GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
                lightUp = false;
            }
            
            GetComponent<Rigidbody>().useGravity = false;
            game.GetComponent<GameControl>().SetLanterns();
            transform.rotation = Quaternion.identity;




            //upwards = new Vector3(0, .04f, 0);
            // transform.position = transform.position + upwards;

            Vector3 force = Vector3.up * floatStrength;
            GetComponent<Rigidbody>().AddForce(force);
        }
        
    }
    
    
}
