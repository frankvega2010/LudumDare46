using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotator : MonoBehaviour
{
    public float speed;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Get().playerGO;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
        transform.position = player.transform.position;
    }
}
