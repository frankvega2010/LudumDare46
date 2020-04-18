using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public LayerMask Mask;

    // Start is called before the first frame update
    void Start()
    {
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
}
