using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public GameObject finishScreen;
    public Text winText;
    public Text lossText;
    public GameObject playerGO;
    public Player player;
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
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(GameManager.Get().gameObject);
        }
    }

    private void GameOver(bool isPlayerAlive)
    {
        //Disable player and enemy functions..

        finishScreen.SetActive(true);

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
