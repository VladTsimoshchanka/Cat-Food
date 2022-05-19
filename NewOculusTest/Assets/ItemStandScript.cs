using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStandScript : MonoBehaviour
{
    public GameObject itemHolder;
    public GameObject item;
    public Transform ItemTransform;
    // Start is called before the first frame update
    //Get the transfrom for the new items
    void Start()
    {
        ItemTransform = itemHolder.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Respawn the item in its old glory
    public void ReincarnateItem()
    {
        Instantiate(item, ItemTransform.position, ItemTransform.rotation);
    }
}
