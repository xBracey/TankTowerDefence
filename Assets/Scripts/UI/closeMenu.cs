using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeMenu : MonoBehaviour
{
    GameObject sidebar;
    Vector3 openPosition;
    Vector3 closePosition;

    void Start()
    {
        sidebar = GameObject.Find("Sidebar");
        openPosition = sidebar.transform.localPosition;

        closePosition = new Vector3(openPosition.x - 200, openPosition.y, openPosition.z);

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(CloseMenu);
    }

    public void OpenMenu()
    {
        sidebar.transform.localPosition = closePosition;
    }

    public void CloseMenu()
    {
        sidebar.transform.localPosition = openPosition;
    }
}
