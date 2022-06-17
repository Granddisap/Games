using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject USure, creditText, options, startScreen, continueButton;
    

    [SerializeField]
    public AudioSource buttonSound;

    public void StartScreen()
    {
        buttonSound.Play();
        startScreen.SetActive(true);
    }

    public void SoundButton()
    {
        buttonSound.Play();
    }
    public void Options()
    {
        buttonSound.Play();

        options.SetActive(true);
    }

    public void Credit()
    {
        buttonSound.Play();

        if (creditText.activeSelf == false)
        {
            creditText.SetActive(true);
        }
        else
        {
            creditText.SetActive(false);
        }
    }

    public void Exit()
    {
        buttonSound.Play();

        USure.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (options.activeSelf == false)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                USure.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (File.Exists(Application.persistentDataPath + "/player.nm"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }
}
