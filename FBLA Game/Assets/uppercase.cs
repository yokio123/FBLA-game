using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uppercase : MonoBehaviour
{
    public TMP_InputField inputField;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     
        
     inputField.text = inputField.text.ToUpper();
     
        

    }
}
