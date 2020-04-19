using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
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
                PlayerState.Get().hasPlayerWon = true;
                Destroy(GameManager.Get().gameObject);
            }
        }
    }

    private void GameOver(bool isPlayerAlive)
    {
        //Disable player and enemy functions..

        finishScreen.SetActive(true);
        isFinished = true;

        player.enabled = false;

        if (isPlayerAlive)
        {
            winText.gameObject.SetActive(true);
        }
        else
        {
            lossText.gameObject.SetActive(true);
        }
        
    }

    private void OnDestroy()
    {
        CollectibleManager.OnCollectiblesDone -= GameOver;
        Player.OnPlayerGameOver -= GameOver;
        //player = playerGO.GetComponent<Player>();
    }
}
