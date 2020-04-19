using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public bool isInArea1, isInArea2, isInArea3;
    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.Get().playerGO.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Get().player.follow1 && isInArea1)
        {
            agent.SetDestination(target.position);
        }
        if (GameManager.Get().player.follow2 && isInArea2)
        {
            agent.SetDestination(target.position);
        }
        if (GameManager.Get().player.follow3 && isInArea3)
        {
            agent.SetDestination(target.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            Debug.Log("rip2");
            Destroy(this.gameObject);
        }
    }
}
