using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    private AsyncOperation asyncLoad;

    [SerializeField] private GameObject loadingScreenNextScene, pressAnyKeyAnim;
    [SerializeField] private Slider bar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("NextScene", 1);
            loadingScreenNextScene.SetActive(true);
            StartCoroutine(LoadAsync());
        }
    }

    IEnumerator LoadAsync()
    {
        //загрузка сцены
        asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone) //пока не прогрузилась сцена
        {
            bar.value = asyncLoad.progress;

            //проверка на возможность загрузки уровня и заполненности шкалы загрузки
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                pressAnyKeyAnim.SetActive(true);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
