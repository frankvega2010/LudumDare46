using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public GameObject UIScreen;
    public GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        CollectibleManager.OnCollectiblesDone += GameOver;
        UIScreen.SetActive(false);
    }

    private void GameOver()
    {
        UIScreen.SetActive(true);
    }

    private void OnDestroy()
    {
        CollectibleManager.OnCollectiblesDone -= GameOver;
    }
}
