using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    //[SerializeField] private GameObject highscoreEntryContainer, highscoreEntryTemplate;
    [SerializeField] private Text posText, scoreText, nameText;
    [SerializeField] private Image trophy;

    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;

    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            AddHighscoreEntry(-1, "JOE");// Заглушка из-за некорректного вывода 1 элемента

            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        // Сортируем таблицу по самому высокому рекорду
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // Свапаем
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        //float templateHeight = 1f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        posText.GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        scoreText.GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        nameText.GetComponent<Text>().text = name;

        // Цвет звездочки в зависимости от места
        switch (rank)
        {
            default:
                trophy.gameObject.SetActive(false);
                break;
            case 1:
                trophy.GetComponent<Image>().color = new Color(1f, .82f, 0f);
                break;
            case 2:
                trophy.GetComponent<Image>().color = new Color(.78f, .78f, .78f);
                break;
            case 3:
                trophy.GetComponent<Image>().color = new Color(.72f, .43f, .34f);
                break;

        }

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
    {
        // Создаем HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Загрузка/сохранение Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // Если нет сохраненной таблицы, то создаем
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Добавляем нового пользователя
        highscores.highscoreEntryList.Add(highscoreEntry);

        // СОхроняем это добавление
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //Одна запись с высоким бвллом
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
