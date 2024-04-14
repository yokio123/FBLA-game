using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipTutorial : MonoBehaviour
{
    void Start()
    {
        Button button = gameObject.GetComponent(typeof(Button)) as Button;
        button.onClick.AddListener(SkipTutorialButtonClick);
    }

    void SkipTutorialButtonClick()
    {
        SceneManager.LoadScene("lvl 1");
    }
}
