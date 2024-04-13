using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CapitalusMaximusController : MonoBehaviour
{
    [SerializeField] GameObject trashTalkGameObject;
    [SerializeField] GameObject goldCounterGameObject;
    TextMeshPro trashTalkTMP;
    TextMeshPro goldCounterTMP;

    float timeToLastRefresh = 0;
    float timeTillRefresh;
    float currentTimeElapsed = 0;
    float minRefreshWait = 3;
    float maxRefreshWait = 15;

    static int gold = 0;
    int minGoldOnRefresh = 3;
    int maxGoldOnRefresh = 25;

    List<string> trashTalkPhrases = new List<string>()
    {
        "a",
        "b",
        "c",
        "Ha ha, another great deal!"
    };
    string lastPhraseSelected = "";

    // Start is called before the first frame update
    void Start()
    {
        trashTalkTMP = trashTalkGameObject.GetComponent(typeof(TextMeshPro)) as TextMeshPro;
        goldCounterTMP = goldCounterGameObject.GetComponent(typeof(TextMeshPro)) as TextMeshPro;
        timeTillRefresh = Random.Range(minRefreshWait, maxRefreshWait);
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeElapsed = Timer.timeElapsed;
        if (currentTimeElapsed >= Timer.totalTime)
        {
            trashTalkTMP.text = "I win!";
        } else if (currentTimeElapsed >= timeToLastRefresh + timeTillRefresh)
        {
            Refresh();
        }
    }

    void Refresh()
    {
        timeToLastRefresh += timeTillRefresh;
        timeTillRefresh = Random.Range(minRefreshWait, maxRefreshWait);
        List<string> filteredList = trashTalkPhrases.Where((phrase) => (phrase != lastPhraseSelected)).ToList(); // Ensure the phrase is never the same
        lastPhraseSelected = filteredList[Random.Range(0, trashTalkPhrases.Count - 1)];
        trashTalkTMP.text = lastPhraseSelected;
        float goldMultiplier = 3f * (currentTimeElapsed / Timer.totalTime);
        gold += Mathf.FloorToInt(Random.Range(minGoldOnRefresh, maxGoldOnRefresh) * goldMultiplier);
        goldCounterTMP.text = $"Gold: {gold}";
    }
}
