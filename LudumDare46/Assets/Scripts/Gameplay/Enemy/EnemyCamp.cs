using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamp : MonoBehaviour
{
    public GameObject enemyCampParent;
    public Hitbox areaTrigger;
    public int maxEnemiesAmount;

    public EnemyController[] enemiesOriginal;
    public EnemyController[] enemiesController;
    public GameObject[] enemies;
    public int enemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        areaTrigger.OnHitboxTrigger += GoToPlayer;
        enemiesOriginal = new EnemyController[enemyCampParent.transform.childCount];
        enemiesController = new EnemyController[enemyCampParent.transform.childCount];
        enemies = new GameObject[enemyCampParent.transform.childCount];

        for (int i = 0; i < enemyCampParent.transform.childCount; i++)
        {
            enemiesOriginal[i] = enemyCampParent.transform.GetChild(i).GetComponent<EnemyController>();
            enemiesOriginal[i].gameObject.SetActive(false);
            //posibleLocations.Add(spawnLocations[i]);
        }

        Spawn();
    }

   /* // Update is called once per frame
    void Update()
    {
        
    }*/

    private void Spawn()
    {
        for (int i = 0; i < enemiesOriginal.Length; i++)
        {
            enemies[i] = Instantiate(enemiesOriginal[i].gameObject, enemiesOriginal[i].transform.position, enemiesOriginal[i].transform.rotation);
            enemiesController[i] = enemies[i].GetComponent<EnemyController>();
            enemiesController[i].OnEnemyDeath += CheckEnemies;
            enemies[i].gameObject.SetActive(true);

        }

        enemiesLeft = enemies.Length;
    }

    private void GoToPlayer()
    {
        for (int i = 0; i < enemiesController.Length; i++)
        {
            enemiesController[i].canFollow = true;
        }
    }

    private void CheckEnemies()
    {
        enemiesLeft--;

        if(enemiesLeft <= 0)
        {
            Spawn();
        }
    }

    private void OnDestroy()
    {
        areaTrigger.OnHitboxTrigger -= GoToPlayer;
        //enemiesController[i].OnEnemyDeath -= CheckEnemies;
    }
}
