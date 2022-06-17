using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGame : MonoBehaviour
{
    [SerializeField] private LeaderBoard leaderBoard;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("highscoreTable") == false)
        {
            leaderBoard.AddHighscoreEntry(-1, "-1");
            leaderBoard.AddHighscoreEntry(143000, "Lola");
            leaderBoard.AddHighscoreEntry(131000, "Barley");
            leaderBoard.AddHighscoreEntry(107500, "Bea");
            leaderBoard.AddHighscoreEntry(73200, "Bull");
            leaderBoard.AddHighscoreEntry(41800, "Colette");
            leaderBoard.AddHighscoreEntry(25500, "Edgar");
        }
    }
}
