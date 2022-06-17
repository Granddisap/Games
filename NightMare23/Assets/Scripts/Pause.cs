using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject uSure, pause, options, dethScreen;

    [SerializeField]
    private AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!uSure.activeSelf && !dethScreen.activeSelf)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Continue()
    {
        buttonSound.Play();
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        buttonSound.Play();

        options.SetActive(true);
    }

    public void BackMainMenu()
    {
        buttonSound.Play();
        uSure.SetActive(true);
        pause.SetActive(false);
    }
}
