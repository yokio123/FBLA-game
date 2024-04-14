using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = $"Gold:\n{PlayerTradesManager.gold}";
    }
}
