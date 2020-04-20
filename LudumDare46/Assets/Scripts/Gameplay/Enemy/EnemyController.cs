using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public delegate void OnEnemyAction();
    public OnEnemyAction OnEnemyDeath;

    public bool isInArea1, isInArea2, isInArea3;
    public bool canFollow;
    Transform target;
    NavMeshAgent agent;
    public float timer;
    public float deathTime;
    public Material damage;
    public Material normal;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.Get().playerGO.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canFollow)
        {
            agent.SetDestination(target.position);
        }

        /*if (GameManager.Get().player.follow1 && isInArea1)
        {
            Destroy(this.gameObject); // test
            agent.SetDestination(target.position);
        }
        if (GameManager.Get().player.follow2 && isInArea2)
        {
            agent.SetDestination(target.position);
        }
        if (GameManager.Get().player.follow3 && isInArea3)
        {
            agent.SetDestination(target.position);
        }*/

        if (timer>deathTime)
        {
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
            SoundManager.Get().PlaySound("Ghost_rip");
            if (OnEnemyDeath != null)
            {
                OnEnemyDeath();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            gameObject.GetComponent<MeshRenderer>().material = damage;
        }

        if (other.gameObject.tag == "Shield")
        {
            Debug.Log("rip2");
            Destroy(this.gameObject);
            SoundManager.Get().PlaySound("Shield_crack");
            SoundManager.Get().PlaySound("Ghost_rip");

            if(OnEnemyDeath != null)
            {
                OnEnemyDeath();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            gameObject.GetComponent<MeshRenderer>().material = normal;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            timer += Time.deltaTime;
        }
    }

}
