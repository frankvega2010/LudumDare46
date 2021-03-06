﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public float waitingTime;
    public SceneChanger scenes;
    public GameObject finishScreen;
    public Text winText;
    public Text lossText;
    public GameObject playerGO;
    public Player player;
    private float waitingTimer;
    private bool isFinished;
    private bool doOnce;
    // Start is called before the first frame update
    void Start()
    {
        //playerGO = GameObject.FindGameObjectWithTag("Player");
        player = playerGO.GetComponent<Player>();
        CollectibleManager.OnCollectiblesDone += GameOver;
        Player.OnPlayerGameOver += GameOver;
        finishScreen.SetActive(false);
        winText.gameObject.SetActive(false);
        lossText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            scenes.ChangeScene("Main Menu");
            Destroy(GameManager.Get().gameObject);
        }

        if(isFinished)
        {
            waitingTimer += Time.deltaTime;

            if(waitingTimer >= waitingTime)
            {
               // scenes.sceneToChange("Credits Menu");
                scenes.ChangeScene("Main Menu");
                
                Destroy(GameManager.Get().gameObject);
            }
        }
    }

    private void GameOver(bool isPlayerAlive)
    {
        //Disable player and enemy functions..

        if(!doOnce)
        {
            finishScreen.SetActive(true);
            isFinished = true;

            player.enabled = false;

            if (isPlayerAlive)
            {
                PlayerState.Get().hasPlayerWon = true;
                winText.gameObject.SetActive(true);
            }
            else
            {
                PlayerState.Get().hasPlayerWon = false;
                lossText.gameObject.SetActive(true);
            }

            doOnce = true;
        }

    }

    private void OnDestroy()
    {
        CollectibleManager.OnCollectiblesDone -= GameOver;
        Player.OnPlayerGameOver -= GameOver;
        //player = playerGO.GetComponent<Player>();
    }
}
