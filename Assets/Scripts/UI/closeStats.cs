using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeStats : MonoBehaviour
{
    GameObject stats;
    Vector3 statsOriginalPosition;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("tankStats");
        statsOriginalPosition = stats.transform.position;

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(CloseStats);
    }

    public void CloseStats()
    {
        stats.transform.position = statsOriginalPosition;
    }
}
