using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TraderMenu : SpaceToInteract
{
    // Update is called once per frame
    void Start()
    {
        MakeInteractText();
        OnInteractStartEvent.AddListener(DisplayTraderUI);
        OnInteractEndEvent.AddListener(HideTraderUI);
    }

    void DisplayTraderUI()
    {
        PlayerMovement.playerCanMove = false;
        dataManager.traderUI.SetActive(true);
    }

    void HideTraderUI()
    {
        PlayerMovement.playerCanMove = true;
        dataManager.traderUI.SetActive(false);
    }
}
