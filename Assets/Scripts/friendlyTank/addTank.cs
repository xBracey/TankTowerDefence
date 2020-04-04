using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addTank : MonoBehaviour
{
    GameObject map;
    Text price;
    protected string tankName;
    protected float tankRadius;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("map");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(AddTank);
    }

    public void AddTank()
    {
        map mapScript = map.GetComponent<map>();

        mapScript.tank = GameObject.Find(tankName);

        BoxCollider collider = map.GetComponent<BoxCollider>();
        collider.enabled = true;
    }
}
