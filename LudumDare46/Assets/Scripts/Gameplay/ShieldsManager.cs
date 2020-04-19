using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldsManager : MonoBehaviour
{
    public float waitingTime;

    public int maxActiveShields;
    public GameObject spawnsParent;
    public GameObject shieldPrefab;

    public Transform[] spawnLocations;
    public List<Transform> posibleLocations;
    private float timer;
    public int activeShields;

    // Start is called before the first frame update
    void Start()
    {
        ShieldItem.OnShieldRecovered += CheckShields;

        spawnLocations = new Transform[spawnsParent.transform.childCount];

        for (int i = 0; i < spawnsParent.transform.childCount; i++)
        {
            spawnLocations[i] = spawnsParent.transform.GetChild(i).GetComponent<Transform>();
            posibleLocations.Add(spawnLocations[i]);
        }

        //collectiblesLeft = collectiblesAmount;
        //SpawnCollectible();
        SpawnShield(maxActiveShields);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= waitingTime)
        {
            if(activeShields < maxActiveShields)
            {
                SpawnShield(maxActiveShields-activeShields);
            }

            timer = 0;
        }
    }

    private void SpawnShield(int shieldsAmount)
    {
        for (int j = 0; j < shieldsAmount; j++)
        {
            Transform newLocation = posibleLocations[Random.Range(0, posibleLocations.Count - 1)];
            GameObject newShield = Instantiate(shieldPrefab, newLocation.position, newLocation.rotation);

            //newCollectible.GetComponent<Collectible>().OnCollectibleGrab += GrabCollectible;

            posibleLocations.Remove(newLocation);

            if (posibleLocations.Count <= 0)
            {
                for (int i = 0; i < spawnsParent.transform.childCount; i++)
                {
                    posibleLocations.Add(spawnLocations[i]);
                }
            }

            activeShields++;
        }
        
    }

    private void CheckShields(GameObject currentItem)
    {
        if(GameManager.Get().player.canPickUpShield)
        {
            activeShields--;
        }
    }

    private void OnDestroy()
    {
        ShieldItem.OnShieldRecovered -= CheckShields;
    }
}
