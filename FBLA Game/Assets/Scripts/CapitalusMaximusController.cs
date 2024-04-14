using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public static int gold = 0;
    int minGoldOnRefresh = 3;
    int maxGoldOnRefresh = 25;

    List<string> trashTalkPhrases = new List<string>()
    {
        "Another great deal, a rarity for you",
        "Ha ha, my wealth grows in magnitudes",
        "All in a day's work",
        "Ha ha, another great deal!",
        "It seems like you're lacking in wares",
        "Your wallet is like a beggar's hat",
        "My gold is to much for your penny pocket to handle",
        "The wealth keeps flowing in like waves",
        "Still trading wood peasant?",
        "Money grows on trees, at least when you are me",
        "You're like a broken record, repeating the same mistakes over and over again.",
        "I can make more than you with my eyes closed",
        "Do you even know what you're doing, or are you just making it up as you go?",
        "You call that a strategy? I've seen better from a toddler playing with blocks!",
        "Get a different job. Stocks are too complicated for you.",
        "You call that a strategy? I've seen hatchlings make better decisions!",
        "I am and will always be the richest dino"
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
