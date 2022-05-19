using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaloonControl : MonoBehaviour
{
    public Text baloonCount;
    private bool wasGrabbed = false;
    public GameObject balloonPrefab;
    private GameObject balloon;
    public float floatStrength = 5f;
    private OVRGrabbable grabScript;
    // Start is called before the first frame update
    void Start()
    {
        grabScript = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabScript.isGrabbed)
        {
            InflateBaloon();
            wasGrabbed = true;
        }
        else if (!grabScript.isGrabbed && wasGrabbed)
        {
            ReleaseBaloon(0.0f);
        }
    }
    public void InflateBaloon()
    {
        transform.localScale += new Vector3((float).01, (float).01, (float).01);
        //Rigidbody rb = GetComponent<Rigidbody>();
        //Vector3 force = Vector3.up * floatStrength;
        //rb.AddForce(force);
        //GameObject.Destroy(balloon, 10f);
        //balloon = null;
    }
    public void ReleaseBaloon( float height)
    {
        baloonCount.text = " Ballons Released: 1";
        if(height < 10.0)
        {
            //Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 force = Vector3.up * floatStrength;
            GetComponent<Rigidbody>().AddForce(force);
            //GameObject.Destroy(balloon, 10f);
            //balloon = null;
            height += Time.deltaTime;
        }

    }
}

