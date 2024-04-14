using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TraderMenu : SpaceToInteract
{
    public string traderName;
    public bool isBuyer = false;
    public ItemType itemType;
    int tradePrice;
    int tradeQuantity;
    float multiplier;

    float timeToLastRefresh = 0;
    float timeTillRefresh;
    float minRefreshWait = 3;
    float maxRefreshWait = 15;

    List<string> tradingPhrases = new List<string>()
    {
        "Hey there! Ready to make a deal?",
        "Good to see you again! What can I do for you today?",
        "Welcome back! Let's find you something special.",
        "Well, hello! Looking for some treasures today?",
        "Hey, friend! What's on your mind?",
        "Ah, it's you! Always a pleasure. What's the plan?",
        "Nice to see a familiar face! What brings you by?",
        "Hey, hey! Ready to explore some trading opportunities?",
        "Well, well, well! Look who's back for more adventures.",
        "Hey, good lookin'! What can I help you find today?",
        "Well, hello there, partner! Ready to explore some trading opportunities?",
        "Good day, partner! Let's find something special just for you.",
        "Greetings, partner! Ready to discover some hidden gems?",
        "Hey, hey, hey, partner! Ready to dive into some exciting deals?",
        "Well met, partner! Let's make some magic happen today.",
        "Greetings, esteemed partner! What brings you by today?",
        "Greetings, partner! What can I assist you with this time around?",
        "Well, well, well, partner! Look who's back for another round.",
        "Hello again, partner! Ready to turn the tide in your favor?",
        "Good to see you, partner! Let's make some magic happen.",
        "Hey, nice to see you, friend! What can I do for you today?",
        "Ah, it's you again, friend! Always a pleasure to have you here.",
        "Welcome back, friend! What treasures do you seek today?",
        "Hey, good to have you back, friend! What's the plan for today?",
        "Hello again, friend! What can I assist you with this time around?",
        "Hey there, friend! What's on your shopping list?",
        "Good to see you, friend! Let's make today a day to remember.",
        "Hey, it's you, friend! Always a pleasure to see a familiar face.",
        "Welcome back, friend! Let's turn your dreams into reality.",
        "Hey, nice to have you back, friend! Let's find some treasures together."
    };

    Dictionary<ItemType, List<int>> tradeData = new()
    {
        {
            ItemType.Wood, new()
            {
                3, 12, 4, 13, 4, 10
            }
        },
        {
            ItemType.Stone, new()
            {
                10, 24, 11, 31, 2, 8
            }
        },
        {
            ItemType.Iron, new()
            {
                22, 54, 23, 72, 3, 5
            }
        },
        {
            ItemType.Gem, new()
            {
                42, 99, 43, 128, 1, 2
            }
        }
    }; // tradeData[itemType][0 = min buy price, 1 = max buy price, 2 = min sell price, 3 = max sell price, 4: min quantity, 5: max quantity]

    void Refresh()
    {
        timeToLastRefresh += timeTillRefresh;
        timeTillRefresh = Random.Range(minRefreshWait, maxRefreshWait);
        GenerateTradeDetails();
        if (isInteracting) RefreshTraderUI();
    }

    void Start()
    {
        MakeInteractText();
        OnInteractStartEvent.AddListener(DisplayTraderUI);
        OnInteractEndEvent.AddListener(HideTraderUI);
        timeTillRefresh = Random.Range(minRefreshWait, maxRefreshWait);
        GenerateTradeDetails();
    }

    private void FixedUpdate()
    {
        if (Timer.timeElapsed < Timer.totalTime && Timer.timeElapsed >= timeToLastRefresh + timeTillRefresh)
        {
            Refresh();
        }
    }

    void GenerateTradeDetails()
    {
        multiplier = 3 * (Timer.timeElapsed / Timer.totalTime);
        if (multiplier < 1) multiplier = 1;
        if (isBuyer)
        {
            // Buyer
            tradePrice = Mathf.CeilToInt(Random.Range(tradeData[itemType][2], tradeData[itemType][3]));
        } else
        {
            // Seller
            itemType = RandomEnumValue<ItemType>();
            tradePrice = Mathf.CeilToInt(Random.Range(tradeData[itemType][0], tradeData[itemType][1]));
        }

        tradeQuantity = Mathf.CeilToInt(Random.Range(tradeData[itemType][4], tradeData[itemType][5]) * multiplier);

    }

    T RandomEnumValue<T>()
    {
        System.Array arr = System.Enum.GetValues(typeof(T));
        return (T)arr.GetValue(Random.Range(0, arr.Length - 1));
    }

    void RefreshTraderUI()
    {
        {
            Image img = dataManager.traderUITradeIcon.GetComponent(typeof(Image)) as Image;
            Sprite tradeIcon = null;
            if (itemType == ItemType.Wood) tradeIcon = dataManager.woodIcon;
            else if (itemType == ItemType.Stone) tradeIcon = dataManager.stoneIcon;
            else if (itemType == ItemType.Iron) tradeIcon = dataManager.ironIcon;
            else if (itemType == ItemType.Gem) tradeIcon = dataManager.gemIcon;
            img.sprite = tradeIcon;
        }
        {
            TextMeshProUGUI tmp = dataManager.traderUITradeInfoText.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            string text = "";
            if (isBuyer) text += $"Buyinh for:\n{tradePrice} coins";
            else text += $"Selling for:\n{tradePrice} coins";
            text += $"\nStock: {tradeQuantity}";
            tmp.text = text;
        }
        {
            TextMeshProUGUI tmp = dataManager.traderUITradeButton.transform.GetChild(0).GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            if (isBuyer) tmp.text = $"Sell 1";
            else tmp.text = $"Buy 1";
        }
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            Image img = dataManager.traderUITraderIcon.GetComponent(typeof(Image)) as Image;
            img.sprite = spriteRenderer.sprite;
        }
        {
            TextMeshProUGUI tmp = dataManager.traderUINameText.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            tmp.text = traderName;
        }
    }

    void DisplayTraderUI()
    {
        PlayerMovement.playerCanMove = false;
        RefreshTraderUI();
        { // Ensure this only happens once every interaction
            TextMeshProUGUI tmp = dataManager.traderUIPhraseText.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            tmp.text = tradingPhrases[Random.Range(0, tradingPhrases.Count - 1)];
        }
        dataManager.traderUI.SetActive(true);
    }

    void HideTraderUI()
    {
        PlayerMovement.playerCanMove = true;
        dataManager.traderUI.SetActive(false);
    }
}

public enum ItemType
{
    Wood,
    Stone,
    Iron,
    Gem
}
