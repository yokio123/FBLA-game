using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TraderMenu : SpaceToInteract
{
    public string traderName;
    public bool isBuyer = false;
    public ItemType itemType;

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

    // Update is called once per frame
    void Start()
    {
        MakeInteractText();
        OnInteractStartEvent.AddListener(DisplayTraderUI);
        OnInteractEndEvent.AddListener(HideTraderUI);
    }

    void RefreshTraderUI()
    {
        Image img = dataManager.traderUITradeIcon.GetComponent(typeof(Image)) as Image;
        Sprite tradeIcon = null;
        if (itemType == ItemType.Wood) tradeIcon = dataManager.woodIcon;
        else if (itemType == ItemType.Stone) tradeIcon = dataManager.stoneIcon;
        else if (itemType == ItemType.Iron) tradeIcon = dataManager.ironIcon;
        else if (itemType == ItemType.Gem) tradeIcon = dataManager.gemIcon;
        img.sprite = tradeIcon;
    }

    void DisplayTraderUI()
    {
        PlayerMovement.playerCanMove = false;
        RefreshTraderUI();
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
