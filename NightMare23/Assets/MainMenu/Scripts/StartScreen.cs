using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreen;

    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private GameObject USureStartNewGame;

    public void NewGame()
    {
        buttonSound.Play();

        USureStartNewGame.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Continue()
    {
        buttonSound.Play();

        PlayerPrefs.SetInt("Continue", 1);
        loadingScreen.Load();
    }

    public void Back()
    {
        buttonSound.Play();
        gameObject.SetActive(false);
    }
}
