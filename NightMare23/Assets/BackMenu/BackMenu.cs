using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMenu : MonoBehaviour
{
    private AsyncOperation asyncLoad;

    [SerializeField] private GameObject loadingScreenBackMenu, uSure, pause;
    [SerializeField] private Slider bar;

    [SerializeField] private AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void USureOff()
    {
        buttonSound.Play();

        pause.SetActive(true);
        uSure.SetActive(false);
    }

    public void Load()
    {
        buttonSound.Play(); 

        loadingScreenBackMenu.SetActive(true);

        Time.timeScale = 1;
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        //загрузка сцены
        asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone) //пока не прогрузилась сцена
        {
            bar.value = asyncLoad.progress;

            //проверка на возможность загрузки уровня и заполненности шкалы загрузки
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
