using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string loadLevel;

    private AsyncOperation asyncLoad;

    public GameObject loadingScreen;
    public GameObject pressAnyKeyAnim;
    public Slider bar;

    [SerializeField]
    private AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void Load()
    {
        buttonSound.Play();

        loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync() 
    {
        //загрузка сцены
        if (PlayerPrefs.GetInt("Continue") == 0)
        {
            asyncLoad = SceneManager.LoadSceneAsync(1);
        }
        else
        {
            PlayerData data = BinarySavingSystem.LoadPlayer();
            asyncLoad = SceneManager.LoadSceneAsync(data.numberLvl);
        }

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone) //пока не прогрузилась сцена
        {
            bar.value = asyncLoad.progress;

            //проверка на возможность загрузки уровня и заполненности шкалы загрузки
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                pressAnyKeyAnim.SetActive(true);
                if (Input.anyKeyDown) //Нажать любую кнопку для продолжения
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }


}
