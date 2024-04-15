using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft; // Starts at 3 minutes, is in seconds
    public static float timeElapsed = 0; // In seconds
    public static float totalTime = 3 * 60; // 3 minutes in seconds
    public float startTime; // The time when the timer was instantiated, in seconds
    [SerializeField] GameObject secondaryTextGameObject;

    TextMeshProUGUI primaryTmp;
    TextMeshProUGUI secondaryTmp;

    bool gameHasAlreadyEnded = false;

    DataManager dataManager;

    private void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent(typeof(DataManager)) as DataManager;

        timeElapsed = 0;
        timeLeft = totalTime;
        startTime = Time.time;

        primaryTmp = gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        secondaryTmp = secondaryTextGameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    private void Update()
    {
        timeElapsed = Time.time - startTime;
        if (timeElapsed < totalTime)
        {
            timeLeft = totalTime - timeElapsed;
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);
            int decimals = Mathf.FloorToInt(((timeLeft % 60) % 1) * 100);
            primaryTmp.text = $"{minutes}:{seconds:D2}";
            secondaryTmp.text = $".{decimals:D2}";
        } else if (!gameHasAlreadyEnded)
        {
            gameHasAlreadyEnded = true;
            timeLeft = 0f;
            primaryTmp.text = "0:00";
            secondaryTmp.text = ".00";
            StartCoroutine(EndRound());
        }
    }

    private IEnumerator EndRound()
    {
        yield return new WaitForSeconds(3f);
        gold_singleton.Gold = PlayerTradesManager.gold;
        PlayerMovement.playerCanMove = true;
        if (CapitalusMaximusController.gold > PlayerTradesManager.gold)
        {
            CapitalusMaximusController.gold = 0;
            PlayerTradesManager.gold = 0;
            PlayerTradesManager.woodCount = 0;
            PlayerTradesManager.stoneCount = 0;
            PlayerTradesManager.ironCount = 0;
            PlayerTradesManager.gemCount = 0;
            gold_singleton.win = false;
            SceneManager.LoadScene("name input");
        } else if (CharacterController2D.level == 1)
        {
            timeLeft = totalTime;
            startTime = Time.time;
            timeElapsed = 0;
            dataManager.reloadTraders.Invoke();
            gold_singleton.win = true;
            SceneManager.LoadScene("lvl 1-lvl 2");
        } else if (CharacterController2D.level == 2)
        {
            timeLeft = totalTime;
            startTime = Time.time;
            timeElapsed = 0;
            dataManager.reloadTraders.Invoke();
            gold_singleton.win = true;
            SceneManager.LoadScene("name input");
        }
    }
}
