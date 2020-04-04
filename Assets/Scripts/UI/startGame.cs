using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    GameObject mapOne;
    GameObject inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        Debug.Log(button);
        button.onClick.AddListener(StartMapOne);

        mapOne = GameObject.Find("mapOne");
        inGameMenu = GameObject.Find("inGameMenu");
    }

    public void StartMapOne()
    {
        Debug.Log("test");
        mapOne.SetActive(true);
        inGameMenu.SetActive(true);
        gameObject.SetActive(true);
    }
}