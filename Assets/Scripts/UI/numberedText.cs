using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberedText : MonoBehaviour
{
    Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    public void addNumber(int number) {
        int textNumber = Int32.Parse(text.text);
        textNumber += number;
        text.text = textNumber.ToString();
    }

    public void setNumber(int number) {
        int textNumber = Int32.Parse(text.text);
        textNumber = number;
        text.text = textNumber.ToString();
    }

    public int getTextNumber() {
        return Int32.Parse(text.text);
    }
}
