using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Get().PlaySound("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
