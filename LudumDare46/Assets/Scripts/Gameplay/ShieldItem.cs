using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    public delegate void OnShieldItemAction(GameObject currentItem);
    public static OnShieldItemAction OnShieldRecovered;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //

        if (other.tag == "Player")
        {
            if (OnShieldRecovered != null)
            {
                //Debug.Log("nice");
                OnShieldRecovered(this.gameObject);
            }

        }
    }
}
