using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public delegate void OnCollectibleAction(GameObject currentCollectible);
    public static OnCollectibleAction OnCollectibleGrab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //

        if(other.tag == "Player")
        {
            if(OnCollectibleGrab != null)
            {
                //Debug.Log("nice");
                OnCollectibleGrab(this.gameObject);
                SoundManager.Get().PlaySound("Pickup");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
       /* if (other.tag == "Player")
        {
            if (OnCollectibleGrab != null)
            {
                Debug.Log("nice2");
            }

        }*/
    }
}
