using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTradesManager : MonoBehaviour
{
    public static int gold = 0;
    int startingGold = 10;

    // Start is called before the first frame update
    void Start()
    {
        gold = startingGold;
    }

    // Update is called once per frame
    void Update()
    {
        gold = Mathf.FloorToInt(Timer.timeElapsed) + startingGold;
    }
}
