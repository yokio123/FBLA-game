using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class scoreboard : MonoBehaviour
{
    public TMP_Text winLabel;
    public TMP_InputField inputField;

    int score;
    // Start is called before the first frame update
    void Start()
    {
    if (gold_singleton.win == true)
        {
            winLabel.text = ("Game Over, You Win");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)==true && inputField.text.Length > 0)
        {
            name = inputField.text.ToString();

            score = gold_singleton.Gold * 100;
            List<string> newRow = new() { name, score.ToString() };
            List<List<string>> newScoreboard;
            if (SaveLoadManager.HasSaved())
            {
                List<List<string>> oldScoreboard = SaveLoadManager.Load().leaderboard;
                oldScoreboard.Add(newRow);
                newScoreboard = SortScoreboard(oldScoreboard);
            } else
            {
                newScoreboard = new() { newRow };
            }
            SaveLoadManager.Save(new GameState(newScoreboard));
            SceneManager.LoadScene("scoreboard");
        }

        List<List<string>> SortScoreboard(List<List<string>> scoreboard)
        {
            scoreboard.Sort((List<string> x, List<string> y) =>
            {
                if (Convert.ToInt32(x[1]) < Convert.ToInt32(y[1]))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            });
            return scoreboard;
        }
    }
}