using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class USureCloseGame : MonoBehaviour
{
    [SerializeField]
    private GameObject uSure;

    [SerializeField]
    private AudioSource buttonSound;

    public void CloseGame()
    {
        buttonSound.Play();

        Debug.Log("Exit");
        Application.Quit();
    }

    public void USureOff()
    {
        buttonSound.Play();

        uSure.SetActive(false);
        Time.timeScale = 1;
    }
}
