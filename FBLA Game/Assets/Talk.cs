using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Talk : MonoBehaviour
{
    public GameObject gameObject;
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
        if (In_Area == true && Input.GetKeyDown(KeyCode.Space))
        {
           gameObject.SetActive(true);
        }
    }
}