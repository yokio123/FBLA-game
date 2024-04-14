using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTradesManager : MonoBehaviour
{
    public static int gold = 0;
    int startingGold = 50;

    public static int woodCount = 0;
    public static int stoneCount = 0;
    public static int ironCount = 0;
    public static int gemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gold = startingGold;
    }
}
