using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject optoins;

    public AudioSource buttonSound;

    public Slider bar;

    public Dropdown quality;

    public Toggle soundOnOff;

    private void Start()
    {
        //Громкость музыки
        audioMixer.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume") * 20));
        bar.value = PlayerPrefs.GetFloat("Volume");

        //Качество графики
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        quality.value = PlayerPrefs.GetInt("Quality");


        //Вкл/выкл звука
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 1f;
            soundOnOff.isOn = true;
        }
        else if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 0.0001f;
            soundOnOff.isOn = false;
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    public void Sound(bool sound)
    {
        if (sound == true)
        {
            AudioListener.volume = 1f;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            AudioListener.volume = 0.0001f;
            PlayerPrefs.SetInt("Sound", 0);
        }
    }

    public void BackButton()
    {
        buttonSound.Play();
        optoins.SetActive(false);
    }
}
