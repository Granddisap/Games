using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USureStartNewGame : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreen;

    [SerializeField] private GameObject startScreen;
    [SerializeField] private AudioSource buttonSound;

    public void Yes()
    {
        buttonSound.Play();

        PlayerPrefs.SetInt("Continue", 0);
        PlayerPrefs.SetInt("NextScene", 0);
        loadingScreen.Load();
    }

    public void No()
    {
        buttonSound.Play();

        startScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
