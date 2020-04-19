using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void OnPlayerAction(bool isPlayerAlive);
    public static OnPlayerAction OnPlayerGameOver;

    public float speed;
    public LayerMask Mask;

    public GameObject shieldParent;
    public Hitbox playerHitbox;
    public GameObject[] shields;

    public bool follow1, follow2, follow3;
    // Start is called before the first frame update
    void Start()
    {
        playerHitbox.OnHitboxTrigger += KillPlayer;
        ShieldItem.OnShieldRecovered += RecoverShield;
        shields = new GameObject[shieldParent.transform.childCount];

        for (int i = 0; i < shieldParent.transform.childCount; i++)
        {
            shields[i] = shieldParent.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 999, Mask))
        {
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
        }

        Move();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }

    private void RecoverShield(GameObject currentItem)
    {
        
        for (int i = 0; i < shields.Length; i++)
        {
            if(!shields[i].activeSelf)
            {
                SoundManager.Get().PlaySound("Pickup");
                Destroy(currentItem);
                shields[i].SetActive(true);
                i = shields.Length;
            }
        }
    }

    private void KillPlayer()
    {
        // Execute animation.. other stuff..

        Debug.Log("lol");

        if(OnPlayerGameOver != null)
        {
            OnPlayerGameOver(false);
        }
    }

    private void OnDestroy()
    {
        ShieldItem.OnShieldRecovered -= RecoverShield;
        playerHitbox.OnHitboxTrigger -= KillPlayer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Area1")
        {
            follow1 = true;
        }
        if (other.gameObject.tag == "Area2")
        {
            follow2 = true;
        }
        if (other.gameObject.tag == "Area3")
        {
            follow3 = true;
        }
    }
}
