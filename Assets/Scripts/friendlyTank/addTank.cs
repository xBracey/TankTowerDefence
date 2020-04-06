using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addTank : MonoBehaviour
{
    [SerializeField]
    GameObject tank;

    GameObject map;
    GameObject sidebar;
    Text price;
    Vector3 openPosition;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("map");
        sidebar = GameObject.Find("Sidebar");
        openPosition = sidebar.transform.localPosition;

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(AddTank);
    }

    public void AddTank()
    {
        sidebar.transform.localPosition = openPosition;

        map mapScript = map.GetComponent<map>();

        mapScript.tank = tank;

        BoxCollider collider = map.GetComponent<BoxCollider>();
        collider.enabled = true;
    }
}
