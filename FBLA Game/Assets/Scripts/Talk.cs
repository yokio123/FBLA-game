using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Talk : MonoBehaviour
{
    private bool In_Area = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        In_Area = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (In_Area && Input.GetKeyDown(KeyCode.Space))
        {
           gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
