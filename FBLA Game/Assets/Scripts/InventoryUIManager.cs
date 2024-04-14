using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject woodCount;
    [SerializeField] GameObject stoneCount;
    [SerializeField] GameObject ironCount;
    [SerializeField] GameObject gemCount;

    TextMeshProUGUI woodCountText;
    TextMeshProUGUI stoneCountText;
    TextMeshProUGUI ironCountText;
    TextMeshProUGUI gemCountText;

    // Start is called before the first frame update
    void Start()
    {
        woodCountText = woodCount.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        stoneCountText = stoneCount.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        ironCountText = ironCount.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        gemCountText = gemCount.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    // Update is called once per frame
    void Update()
    {
        woodCountText.text = $"Count: {PlayerTradesManager.woodCount}";
        stoneCountText.text = $"Count: {PlayerTradesManager.stoneCount}";
        ironCountText.text = $"Count: {PlayerTradesManager.ironCount}";
        gemCountText.text = $"Count: {PlayerTradesManager.gemCount}";

        if (Input.GetKey(KeyCode.I))
        {
            PlayerMovement.playerCanMove = false;
            CharacterController2D.canInteract = false;
            inventoryUI.SetActive(true);
        } else
        {
            PlayerMovement.playerCanMove = true;
            CharacterController2D.canInteract = true;
            inventoryUI.SetActive(false);
        }
    }
}
