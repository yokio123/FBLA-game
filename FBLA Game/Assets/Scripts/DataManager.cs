using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public GameObject traderUI;
    public GameObject traderUITraderIcon;
    public GameObject traderUINameText;
    public GameObject traderUIPhraseText;
    public GameObject traderUITradeIcon;
    public GameObject traderUITradeInfoText;
    public GameObject traderUITradeButton;
    [HideInInspector] public UnityEvent reloadTraders;

    public Sprite woodIcon;
    public Sprite stoneIcon;
    public Sprite ironIcon;
    public Sprite gemIcon;

    public Sprite beigeBackground;
    public TMP_FontAsset minecraftFont;
}
