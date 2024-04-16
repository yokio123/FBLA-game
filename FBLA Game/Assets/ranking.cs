using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ranking : MonoBehaviour
{
    public GameObject rowsParent;
    List<GameObject> rows = new();

    // Start is called before the first frame update
    void Start()
    {
        int numRows = rowsParent.transform.childCount;
        for (int i = 0; i < numRows; i++)
        {
            rows.Add(rowsParent.transform.GetChild(i).gameObject);
        }
        GameState gameState = SaveLoadManager.Load();
        List<List<string>> leaderboard = SortScoreboard(gameState.leaderboard);
        for (int i = 0; i < leaderboard.Count && i < 10; i++)
        {
            List<string> row = leaderboard[i];
            Debug.Log(row[0] + " " + row[1]);
            SetName(rows[i], row[0]);
            SetGold(rows[i], row[1]);
        }
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

    void SetName(GameObject row, string newName)
    {
        Debug.Log(row.transform.GetChild(1).gameObject.name);
        TextMeshProUGUI tmp = row.transform.GetChild(1).gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        tmp.text = newName;
    }

    void SetGold(GameObject row, string newGoldValue)
    {
        TextMeshProUGUI tmp = row.transform.GetChild(2).gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        tmp.text = newGoldValue;
    }
}
