using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    [HideInInspector] public AudioSource audioPlayer;
    public AudioClip ka_ching;
    public AudioClip eror;

    public Sprite woodIcon;
    public Sprite stoneIcon;
    public Sprite ironIcon;
    public Sprite gemIcon;

    public Sprite beigeBackground;
    public TMP_FontAsset minecraftFont;

    void Start()
    {
        audioPlayer = gameObject.GetOrAddComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioPlayer.clip = clip;
        audioPlayer.Play();
    }
}
