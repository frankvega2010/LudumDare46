using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public delegate void OnHitboxAction();
    public OnHitboxAction OnHitboxTrigger;

    public string tagName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tagName)
        {
            

            if(OnHitboxTrigger != null)
            {
                OnHitboxTrigger();
            }
        }
    }
}
