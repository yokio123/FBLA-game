using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)==true && inputField.text.Length > 0)
        {
            name = inputField.text.ToString();

            PlayerPrefs.SetInt(name, gold_singleton.Gold * 100);
            SceneManager.LoadScene("scoreboard");
        }


    }
}