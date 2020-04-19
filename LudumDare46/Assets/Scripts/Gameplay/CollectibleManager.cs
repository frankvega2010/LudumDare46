using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public delegate void OnCollectiblesAction(bool isPlayerAlive);
    public static OnCollectiblesAction OnCollectiblesDone;

    public int collectiblesAmount;
    public GameObject spawnsParent;
    public GameObject collectiblePrefab;

    public Transform[] spawnLocations;
    public List<Transform> posibleLocations;
    public int collectiblesLeft;


    // Start is called before the first frame update
    void Start()
    {
        Collectible.OnCollectibleGrab += GrabCollectible;

        spawnLocations = new Transform[spawnsParent.transform.childCount];

        for (int i = 0; i < spawnsParent.transform.childCount; i++)
        {
            spawnLocations[i] = spawnsParent.transform.GetChild(i).GetComponent<Transform>();
            posibleLocations.Add(spawnLocations[i]);
        }

        collectiblesLeft = collectiblesAmount;
        SpawnCollectible();
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    private void SpawnCollectible()
    {
        Transform newLocation = posibleLocations[Random.Range(0, posibleLocations.Count - 1)];
        GameObject newCollectible = Instantiate(collectiblePrefab, newLocation.position, newLocation.rotation);

        //newCollectible.GetComponent<Collectible>().OnCollectibleGrab += GrabCollectible;

        posibleLocations.Remove(newLocation);

        if (posibleLocations.Count <= 0)
        {
            for (int i = 0; i < spawnsParent.transform.childCount; i++)
            {
                posibleLocations.Add(spawnLocations[i]);
            }
        }
    }

    private void GrabCollectible(GameObject currentCollectible)
    {
        if (currentCollectible != null)
        {
            //currentCollectible.GetComponent<Collectible>().OnCollectibleGrab -= GrabCollectible;
            Destroy(currentCollectible);
        }

        collectiblesLeft--;

        if (collectiblesLeft <= 0)
        {
            if (OnCollectiblesDone != null)
            {
                OnCollectiblesDone(true);
            }
        }
        else
        {
            SpawnCollectible();
        }
    }

    private Transform GetRandomLocation()
    {
        Debug.Log(posibleLocations.Count);
        return posibleLocations[Random.Range(0,posibleLocations.Count-1)];
    }

    private void OnDestroy()
    {
        Collectible.OnCollectibleGrab -= GrabCollectible;
    }
}
