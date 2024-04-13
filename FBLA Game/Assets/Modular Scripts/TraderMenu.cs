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
        OnInteractEvent.AddListener(DisplayTraderUI);
    }

    void DisplayTraderUI()
    {
        PlayerMovement.playerCanMove = false;
    }
}
