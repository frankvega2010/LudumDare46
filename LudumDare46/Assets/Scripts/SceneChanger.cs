using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public string sceneToChange;
    public GameObject menuCanvas;
    public GameObject creditCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //SoundManager.Get().PlaySound("Menu");
        if (PlayerState.Get().hasPlayerWon)
        {
            GoToCredits();
            PlayerState.Get().hasPlayerWon = false;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChange);
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void PlayButtonSound()
    {
        SoundManager.Get().PlaySound("Boton");
    }

    public void GoToCredits()
    {
        menuCanvas.SetActive(false);
        creditCanvas.SetActive(true);
    }

    public void GoToMenu()
    {
        creditCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
}
