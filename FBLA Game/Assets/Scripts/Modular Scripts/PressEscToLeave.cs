using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEscToLeave : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
